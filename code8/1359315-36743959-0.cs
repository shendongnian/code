    class FormattedStringLabelRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (TextView)Control; // for example
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Fonts/ProximaNova-Bold.otf");  // font name specified here
            label.SetTypeface (font, TypefaceStyle.Normal);
        }
    }
