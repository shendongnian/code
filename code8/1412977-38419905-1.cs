    using System;
    using System.Management;
    namespace ConsoleDemo
    {
    class Printer
    {
     public enum TechnologyType
        {
            Other = 1,
            Unknown = 2,
            Electrophotographic_LED = 3,
            Electrophotographic_Laser = 4,
            Electrophotographic_Other = 5,
            Impact_Moving_Head_Dot_Matrix_9pin = 6,
            Impact_Moving_Head_Dot_Matrix_24pin = 7,
            Impact_Moving_Head_Dot_Matrix_Other = 8,
            Impact_Moving_Head_Fully_Formed = 9,
            Impact_Band = 10,
            Impact_Other = 11,
            Inkjet_Aqueous = 12,
            Inkjet_Solid = 13,
            Inkjet_Other = 14,
            Pen_ = 15,
            Thermal_Transfer = 16,
            Thermal_Sensitive = 17,
            Thermal_Diffusion = 18,
            Thermal_Other = 19,
            Electroerosion = 20,
            Electrostatic = 21,
            Photographic_Microfiche = 22,
            Photographic_Imagesetter = 23,
            Photographic_Other = 24,
            Ion_Deposition = 25,
            eBeam = 26,
            Typesetter = 27
        }
        
        public static void GetPrinterInfo()
        {
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Description");
                var MarkingTechnology = printer.GetPropertyValue("MarkingTechnology");
               var CurrentCapabilities = (string )printer.GetPropertyValue("CurrentCapabilities");
                Console.WriteLine("Name:{0} |(Status: {1} | Description: {2}| Technology: {3} | {4} ",
                    name, status, isDefault, MarkingTechnology , CurrentCapabilities);
            }
        }
    }
