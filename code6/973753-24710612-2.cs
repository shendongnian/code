    // Load up some xml
    string xml = "<root><child>value</child></root>";
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    
    
    byte[] bytes;
    
    // Create zip
    using (MemoryStream ms = new MemoryStream())
    {
        using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create))
        {
            // The name of the xml file inside the zip
            var entry = zip.CreateEntry("myxml_file.xml");
            using (Stream stream = entry.Open())
            {
                // Save the xml file into the zip
                doc.Save(stream);
            }
        }
    
        // Get bytes of zip file
        bytes = ms.GetBuffer();
    }
            
    // Save the file to Debug\Bin\out.zip for testing only (remove from final code)
    File.WriteAllBytes("out.zip", bytes);
    
    // bytes to hex values
    StringBuilder buffer = new StringBuilder();
    
    foreach (byte b in bytes)
        buffer.AppendFormat("{0:X2}", b);
    
    // Results
    Console.WriteLine(buffer);
