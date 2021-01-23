    var footer = document
        .Content
        .InlineShapes
        .AddPicture(AppDomain.CurrentDomain.BaseDirectory + "Images\\footer.png")
         .ConvertToShape();
    footer.WrapFormat.Type = WdWrapType.wdWrapTopBottom;
    // be cooperative with what is already in the Range present
    document.Content.InsertAfter(input);
    var header = document
        .Content
        .InlineShapes
        .AddPicture(AppDomain.CurrentDomain.BaseDirectory+"Images\\header.png")
        .ConvertToShape();
    header.WrapFormat.Type = WdWrapType.wdWrapTopBottom;
