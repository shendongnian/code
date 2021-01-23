    GlyphTypeface glyphTypeface;
    
    using (var memoryPackage = new MemoryPackage())
    {
        using (var fontStream = new MemoryStream(File.ReadAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "font"))))
        {
            var typefaceSource = memoryPackage.CreatePart(fontStream);
    
            glyphTypeface = new GlyphTypeface(typefaceSource);
    
            memoryPackage.DeletePart(typefaceSource);
        }
    }
    
    var familyName = glyphTypeface.FamilyNames[CultureInfo.GetCultureInfo("en-US")];
    
    Console.WriteLine(familyName);
