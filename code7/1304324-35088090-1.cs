	namespace MyProject.Extensions 
	{
		public class SvgViewboxAttachedProperties : DependencyObject
		{
			public static string GetSource(DependencyObject obj)
			{
				return (string) obj.GetValue(SourceProperty);
			}
			public static void SetSource(DependencyObject obj, string value)
			{
				obj.SetValue(SourceProperty, value);
			}
			private static void OnSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
			{
				var svgControl = obj as SvgViewbox;
				if (svgControl != null)
				{
					svgControl.Source = new Uri((string)e.NewValue);
				}                
			}
			public static readonly DependencyProperty SourceProperty =
				DependencyProperty.RegisterAttached("Source",
					typeof (string), typeof (SvgViewboxAttachedProperties),
                                        // default value: null
					new PropertyMetadata(null, OnSourceChanged));
		}
	}
