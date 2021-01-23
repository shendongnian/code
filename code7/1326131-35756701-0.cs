    // Create an XSLT Transformer
    var xslt = new XslCompiledTransform();
    xslt.Load("copydoc.xslt");
    
    var settings = new XmlWriterSettings
    {
        Encoding = new UTF8Encoding(false) // NO BOM
    };
    
    // open all streams for reading and writing
    using (var ms = new MemoryStream())
    {
        using (var xw = XmlWriter.Create(ms, settings))
        {
            // input is the string with the xml input
            using (var sr = new StringReader(input))
            using (var xr = XmlReader.Create(sr))
            {
                xslt.Transform(xr, xw);
                // the memorystream now has the result
            }
        }
    
        Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
    }
