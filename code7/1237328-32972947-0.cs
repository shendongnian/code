    void Main()
    {
      string myXML = @"
      <x>
      <paths>
      <entry path=""C:\Users\Simon\AppData\Roaming\myprogram"" />
      <entry path=""C:\Users\Simon\AppData\Roaming\yourprogram"" />
      <entry path=""C:\Users\Simon\AppData\Roaming\hisprogram"" />
      <entry path=""C:\OtherFolder\DummyProgram"" />
      <entry src=""C:\OtherFolder\DummyProgram"" />
      </paths>
      <Other>Other</Other>
      </x>";
    
    XDocument doc = XDocument.Parse(myXML);
    
      doc.Descendants("entry")
      .Where(xd => xd.Attribute("path") != null &&
          ((string)xd.Attribute("path")).ToLower().Contains("appdata"))
      .ToList()
      .ForEach(e => {
         var oldPath = (string)e.Attribute("path");
         var newPath = @"#{APPDATA}\" + Path.GetFileName(oldPath);
         e.Attribute("path").SetValue(newPath);
         } );
      
      Console.WriteLine( doc.ToString() );
          
    }
 
