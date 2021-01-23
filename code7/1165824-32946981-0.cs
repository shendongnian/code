    public class RichTextBoxHelper : DependencyObject
	{
		public static FlowDocument GetDocumentRtf(DependencyObject obj)
		{
			return (FlowDocument)obj.GetValue(DocumentRtfProperty);
		}
		public static void SetDocumentRtf(DependencyObject obj, FlowDocument value)
		{
			obj.SetValue(DocumentRtfProperty, value);
		}
		public static readonly DependencyProperty DocumentRtfProperty =
		  DependencyProperty.RegisterAttached(
			"DocumentRtf",
			typeof(FlowDocument),
			typeof(RichTextBoxHelper),
			new FrameworkPropertyMetadata
			{
				BindsTwoWayByDefault = true,
				PropertyChangedCallback = (obj, e) =>
				{
					var richTextBox = (RichTextBox)obj;
					richTextBox.Document = e.NewValue as FlowDocument;
				}
			});
	}
