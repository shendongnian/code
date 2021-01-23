    //Create medium tile update
    XmlDocument mediumTemplate = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);
    (mediumTemplate.GetElementsByTagName("image")[0] as XmlElement).SetAttribute("src", "UpdatedLiveTile.png");
    //Create wide tile update
    XmlDocument wideTemplate = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Image);
    (wideTemplate.GetElementsByTagName("image")[0] as XmlElement).SetAttribute("src", "UpdatedLiveTileWide.png");
                        
    //Import the 'binding' node from wideTemplate
    var wideBinding = mediumTemplate.ImportNode(wideTemplate.GetElementsByTagName("binding")[0], true);
    //Add it under 'visual' node in mediumTemplate
    var visualElement = mediumTemplate.GetElementsByTagName("visual")[0];
    visualElement.AppendChild(wideBinding);
    (visualElement as XmlElement).SetAttribute("branding", "none");
    //Now the mediumTemplate has bindings for both medium and wide tile
    //Create tile notification using mediumTemplate and update
    TileNotification notification = new TileNotification(mediumTemplate);
    TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
