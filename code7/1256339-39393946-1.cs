    using System.Windows;
    using System.Windows.Controls.Ribbon;
    using System.Windows.Data;
    using System.Windows.Interactivity;
    
    namespace HQ.Wpf.Util.Behaviors
    {
    	public class BehaviorRibbonButton : Behavior<RibbonButton>
    	{
    		// ************************************************************************
    		public TextWrapping TextWrapping
    		{
    			get { return (TextWrapping)GetValue(TextWrappingProperty); }
    			set { SetValue(TextWrappingProperty, value); }
    		}
    
    		// ************************************************************************
    		public static readonly DependencyProperty TextWrappingProperty =
    			DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(BehaviorRibbonButton), new UIPropertyMetadata(TextWrapping.Wrap, TextWrappingPropertyChangedCallback));
    
    		// ************************************************************************
    		private static void TextWrappingPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    		{
    			var ribbonButton = dependencyObject as BehaviorRibbonButton;
    			if (ribbonButton != null)
    			{
    				ribbonButton.SetTextWrapping();
    			}
    		}
    
    		// ************************************************************************
    		public bool HasTwoLine
    		{
    			get
    			{
    				if (TextWrapping == TextWrapping.NoWrap)
    				{
    					return false;
    				}
    
    				return true;
    			}
    		}
    
    		// ************************************************************************
    		private void SetTextWrapping()
    		{
    			var ribbonButton = this.AssociatedObject as RibbonButton;
    			if (ribbonButton != null)
    			{
    				var ribbonTwoLineText = UiUtility.FindVisualChild<RibbonTwoLineText>(ribbonButton);
    				if (ribbonTwoLineText != null)
    				{
    					ribbonTwoLineText.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
    
    					var binding = new Binding("HasTwoLine");
    					binding.Source = this;
    					binding.Mode = BindingMode.OneWay;
    					ribbonTwoLineText.SetBinding(RibbonTwoLineText.HasTwoLinesProperty, binding);
    				}
    			}
    		}
    
    		// ************************************************************************
    		protected override void OnAttached()
    		{
    			base.OnAttached();
    
    			this.AssociatedObject.Loaded += AssociatedObjectOnLoaded;
    		}
    
    		// ************************************************************************
    		private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs routedEventArgs)
    		{
    			SetTextWrapping();
    		}
    
    		// ************************************************************************
    	}
    }
