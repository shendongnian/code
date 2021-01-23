    Style style = new Style(typeof(Image));
    // Style Setter to handle 'false' case
    style.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri("Resources/image2.png", UriKind.Relative))));
    // DataTrigger to handle 'true' case
    DataTrigger dataTrigger = new DataTrigger();
    dataTrigger.Binding = new Binding("Value");
    dataTrigger.Value = true;
    dataTrigger.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri("Resources/image1.png", UriKind.Relative))));
    style.Triggers.Add(dataTrigger);
    this.image.Style = style;
