	using System;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows;
	using System.Windows.Interactivity;
	
	// Sets properties on targeted items via XAML.
	public class SetPropertyBehavior : Behavior<FrameworkElement>
	{
		// Name of the property we want to set on our target.
		public static DependencyProperty PropertyNameProperty =
			DependencyProperty.Register( "PropertyName", typeof( string ), typeof( SetPropertyBehavior ),
			new PropertyMetadata( OnTargetPropertyOrValueChanged ) );
		public string PropertyName
		{
			get { return (string)GetValue( PropertyNameProperty ); }
			set { SetValue( PropertyNameProperty, value ); }
		}
		// Value of the property we want to set.
		public static DependencyProperty PropertyValueProperty =
			DependencyProperty.Register( "PropertyValue", typeof( object ), typeof( SetPropertyBehavior ),
			new PropertyMetadata( OnTargetPropertyOrValueChanged ) );
		public object PropertyValue
		{
			get { return GetValue( PropertyValueProperty ); }
			set { SetValue( PropertyValueProperty, value ); }
		}
		// Target object that has the property we want to set. If this is null, the behavior's
		// associated object will be the target instead.
		public static DependencyProperty TargetProperty =
			DependencyProperty.Register( "Target", typeof( object ), typeof( SetPropertyBehavior ),
			new PropertyMetadata( OnTargetPropertyOrValueChanged ) );
		public object Target
		{
			get { return GetValue( TargetProperty ); }
			set { SetValue( TargetProperty, value ); }
		}
		protected override void OnAttached()
		{
			UpdateTargetProperty();
		}
		private static void OnTargetPropertyOrValueChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			var behavior = d as SetPropertyBehavior;
			if( behavior != null )
				behavior.UpdateTargetProperty();
		}
		private void UpdateTargetProperty()
		{
			// Ensure we have a property name and target to work with.
			if( string.IsNullOrEmpty( this.PropertyName ) )
				return;
			var target = this.Target ?? this.AssociatedObject;
			if( target == null )
				return;
			// Make sure our property is actually on our target.
			var targetType = target.GetType();
			PropertyInfo propInfo = targetType.GetProperty( this.PropertyName,
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
			if( propInfo == null )
				return;
			// Try to convert the string from the XAML to a value the target property can store.
			TypeConverter converter = TypeDescriptor.GetConverter( propInfo.PropertyType );
			object propValue = null;
			try
			{
				if( converter.CanConvertFrom( this.PropertyValue.GetType() ) )
					propValue = converter.ConvertFrom( this.PropertyValue );
				else
					propValue = converter.ConvertFrom( this.PropertyValue.ToString() );
			}
			catch( Exception )
			{
				// Do whatever is appropriate in your case.
				propValue = null;
			}
			propInfo.SetValue( target, propValue );
		}
	}
