    using System;
    using System.Management;
    namespace ConsolDemo
    {
    class Printer
    {
     public    enum TechnologyType
        {
            Other = 1,
            Unknown = 2,
            Electrophotographic, LED_ = 3,
            Electrophotographic_Laser_ = 4,
            Electrophotographic_Other_ = 5,
            Impact_Moving_Head_Dot_Matrix_9pin_ = 6,
            Impact_Moving_Head_Dot_Matrix_24pin_ = 7,
            Impact_Moving_Head_Dot_Matrix_Other_ = 8,
            Impact_Moving_Head_Fully_Formed_ = 9,
            Impact_Band_ = 10,
            Impact_Other_ = 11,
            Inkjet_Aqueous_ = 12,
            Inkjet_Solid_ = 13,
            Inkjet_Other_ = 14,
            Pen_ = 15,
            Thermal_Transfer_ = 16,
            Thermal_Sensitive_ = 17,
            Thermal_Diffusion_ = 18,
            Thermal_Other_ = 19,
            Electroerosion_ = 20,
            Electrostatic_ = 21,
            Photographic_Microfiche_ = 22,
            Photographic_Imagesetter_ = 23,
            Photographic_Other_ = 24,
            Ion_Deposition_ = 25,
            eBeam_ = 26,
            Typesetter_ = 27
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
