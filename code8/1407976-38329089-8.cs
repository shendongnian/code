    using System.Xml.Linq;
    using Windows.Storage;
    using System.IO;
    using System.Linq;
    private void cmdStart_Click(object sender, RoutedEventArgs e)
    {
        SaveXml();
    }
    private async void SaveXml()
    {
       string XML_DATA_FILE = "Customer.xml";
       string customerXMLPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, XML_DATA_FILE);
            
        if (File.Exists(xmlPath))
        {             
             
          XDocument xmlDoc = XDocument.Load(customerXMLPath);
          var updateQuery = from r in xmlDoc.Descendants("Customer")
                      where r.Element("CustomerId").Value == txtCustomerId.Text
                      select r;
         foreach (var query in updateQuery)
         {
             query.Element("State").SetValue(txtState.Text);
         }                             
         StorageFolder storageFolder = ApplicationData.Current.LocalFolder;                
         var newfile = await storageFolder.CreateFileAsync(XML_DATA_FILE, 
         CreationCollisionOption.ReplaceExisting);
                
         await FileIO.WriteTextAsync(newfile, xmlDoc.ToString());                
        }            
    }
