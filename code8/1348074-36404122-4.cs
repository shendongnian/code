    // font overrides
    TextElement.FontFamilyProperty.OverrideMetadata(typeof(TextElement),
        new FrameworkPropertyMetadata(new FontFamily("Verdana")));
    TextBlock.FontFamilyProperty.OverrideMetadata(typeof(TextBlock),
        new FrameworkPropertyMetadata(new FontFamily("Verdana")));
    Control.FontFamilyProperty.OverrideMetadata(typeof(TextBoxBase),
        new FrameworkPropertyMetadata(new FontFamily("Verdana")));
