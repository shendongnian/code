    using System.IO;
    using System.Reflection;
    using OfficeOpenXml;
    //Create a stream of .xlsx file contained within my project using reflection
    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EPPlusTest.templates.VendorTemplate.xlsx");            
    //EPPlusTest = Namespace/Project
    //templates = folder
    //VendorTemplate.xlsx = file
    //ExcelPackage has a constructor that only requires a stream.
      ExcelPackage pck = new OfficeOpenXml.ExcelPackage(stream);
