    public class BorderedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.CornerRadius = 3;
                Control.Layer.BorderColor = Color.FromHex("F0F0F0").ToCGColor();
                Control.Layer.BorderWidth = 2;
            }
        }
    }
