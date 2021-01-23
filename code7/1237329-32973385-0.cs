    void Main()
    {
      string myXML = @"
      <x>
      <paths>
      <entry path=""#{APPDATA}\myprogram"" />
      <entry path=""#{APPDATA}\yourprogram"" />
      <entry path=""#{APPDATA}\hisprogram"" />
      <entry path=""C:\OtherFolder\DummyProgram"" />
      <entry src=""C:\OtherFolder\DummyProgram"" />
      </paths>
      <Other>Other</Other>
      </x>";
    
      var appdata = Environment.GetFolderPath( 
        Environment.SpecialFolder.ApplicationData );
    XDocument doc = XDocument.Parse(myXML);
    
      doc.Descendants("entry")
      .Where(xd => xd.Attribute("path") != null &&
          ((string)xd.Attribute("path")).StartsWith("#{APPDATA}"))
      .ToList()
      .ForEach(e => {
         var oldPath = (string)e.Attribute("path");
         var newPath = Path.Combine(appdata, Path.GetFileName(oldPath));
         e.Attribute("path").SetValue(newPath);
         } );
      
      Console.WriteLine( doc.ToString() );
          
    }
