       // Loads the document
       XDocument xDocument = XDocument.Load("document.xml");
                // Specifies the encoding
			    new XDeclaration("1.0","utf-8","yes");
                // Follows the route settings-font and replaces the current colour 
                // element with a new one
			    xDocument.Element("Settings").Element("Font").Element("Colour").ReplaceWith(new XElement("Colour",fontColourHex));
               // As above
			    xDocument.Element("Settings").Element("Background").Element("Colour").ReplaceWith(new XElement("Colour",backgroundColourHex));
                // One of the more important things to note is that everything saved in an 
                // element ought to be a string, and the xml file doesn't like element 
                // names with spaces in them (use an underscore instead)
			    xDocument.Element("Settings").Element("Font").Element("Size_Modifier").ReplaceWith(new XElement("Size_Modifier",globalFontSizeModifier.ToString()));
			    // Saves the document
			    xDocument.Save("document.xml");
