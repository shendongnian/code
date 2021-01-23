    //Get SdtElement (can be a block, run... so I use the base class) with corresponding Tag
    SdtElement block = doc.MainDocumentPart.Document.Body.Descendants<SdtElement>()
      .FirstOrDefault(sdt => sdt.SdtProperties.GetFirstChild<Tag>()?.Val == contentControlTag);
    //Get First drawing Element and get the original sizes of placeholder SDT
    //I use SDT placeholder size as maximum size to calculate picture size with correct ratios
    Drawing sdtImage = block.Descendants<Drawing>().First();
    double sdtWidth = sdtImage.Inline.Extent.Cx;
    double sdtHeight = sdtImage.Inline.Extent.Cy;
    double sdtRatio = sdtWidth / sdtHeight;
    *Calculate final width/height of image*
    //Resize picture placeholder
    sdtImage.Inline.Extent.Cx = finalWidth;
    sdtImage.Inline.Extent.Cy = finalHeight;
    //Change width/height of picture shapeproperties Transform
    //This will override above height/width until you manually drag image for example
    sdtImage.Inline.Graphic.GraphicData
        .GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>()
        .ShapeProperties.Transform2D.Extents.Cx = finalWidth;
    sdtImage.Inline.Graphic.GraphicData
        .GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>()
        .ShapeProperties.Transform2D.Extents.Cy = finalHeight;
