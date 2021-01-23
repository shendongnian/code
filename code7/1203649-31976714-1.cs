    public class ComputerSettingResponse
    {
        internal ComputerSetting Settings { get; set; }
    }
    internal class ComputerSetting
    {
        internal string Id { get; set; }
        internal string HospitalName { get; set; }
        internal string ComputerType { get; set; }
        internal string Environment { get; set; }
        internal string LabelPrinterName { get; set; }
        internal string DocumentPrinterName { get; set; }
    }
                string xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
    <response>
    	<computer_setting id=""1"" hospital_name=""foo"" computer_type=""bar"" environment=""staging"" label_printer_name=""labels"" document_printer_name=""docs""/>
    </response>     	 ";
            XDocument xDoc = XDocument.Parse(xmlString);
            //XNamespace ns = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");
            string ns = string.Empty;
            List<ComputerSettingResponse> collection = new List<ComputerSettingResponse>
            (
                from list in xDoc.Descendants(ns + "response")
                from item1 in list.Elements(ns + "computer_setting")
                where item1 != null
                select new ComputerSettingResponse
                {
                    //note that the cast is simpler to write than the null check in your code
                    //http://msdn.microsoft.com/en-us/library/bb387049.aspx
                    Settings = new ComputerSetting
                    (
                    ) 
                    {
                        Id = (string)item1.Attribute("id") ?? string.Empty,
                        HospitalName = (string)item1.Attribute("hospital_name") ?? string.Empty,
                        ComputerType = (string)item1.Attribute("computer_type") ?? string.Empty,
                        Environment = (string)item1.Attribute("environment") ?? string.Empty,
                        LabelPrinterName = (string)item1.Attribute("label_printer_name") ?? string.Empty,
                        DocumentPrinterName = (string)item1.Attribute("document_printer_name") ?? string.Empty
                    }
                }
            );
            /* if you know there is only one */
            ComputerSettingResponse returnItem = collection.FirstOrDefault();
