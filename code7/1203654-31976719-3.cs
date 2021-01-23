    using System.Xml.Serialization;
    namespace Casechek.Kiosk
    {
        [XmlRoot("response")]
        public class ComputerSettingResponse
        {
            [XmlElement("computer_setting")]
            public ComputerSetting Settings { get; set; }
        }
        public class ComputerSetting
        {
            [XmlAttribute("id")]
            public string Id { get; set; }
            [XmlAttribute("hospital_name")]
            public string HospitalName { get; set; }
            [XmlAttribute("computer_type")]
            public string ComputerType { get; set; }
            [XmlAttribute("environment")]
            public string Environment { get; set; }
            [XmlAttribute("label_printer_name")]
            public string LabelPrinterName { get; set; }
            [XmlAttribute("document_printer_name")]
            public string DocumentPrinterName { get; set; }
        }
    }
