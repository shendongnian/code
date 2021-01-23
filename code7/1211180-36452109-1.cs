    [assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlaceholderEditorRenderer))]
    namespace Tevel.Mobile.Packages.Droid
    {
   
    public class PlaceholderEditorRenderer : EditorRenderer
    { 
    public PlaceholderEditorRenderer() {  }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var element = e.NewElement as PlaceholderEditor;
                this.Control.Background = Resources.GetDrawable(Resource.Drawable.borderEditText);
                this.Control.Hint = element.Placeholder;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == PlaceholderEditor.PlaceholderProperty.PropertyName)
            {
                var element = this.Element as PlaceholderEditor;
                this.Control.Hint = element.Placeholder;
            }
        }
    }
    }
