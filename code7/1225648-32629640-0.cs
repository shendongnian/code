    var body = doc.MainDocumentPart.Document.Body;
    var pics = body.Descendants<DocumentFormat.OpenXml.Drawing.Pictures.Picture>();
    var result = pics.Select(p => new
        {
            Id = p.BlipFill.Blip.Embed.Value,
            Name = p.NonVisualPictureProperties.NonVisualDrawingProperties.Name.Value
        });
