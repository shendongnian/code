    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    namespace EasyE
    {
    class Program
    {
        static void Main(string[] args)
        {
            // Test strings
            List<extention> extentions = new List<extention>() { 
                new extention { FileName = "File1.jif" }, 
                new extention() { FileName = "File2.TIFF" },
                new extention() { FileName = "File3.txt" } };
            ///////////////
            Regex regex = new Regex(@"^.*\.(tif|tiff|gif|jpeg|jif)$",RegexOptions.IgnoreCase);
            if ((from ext in extentions where (ext.FileName.ToString() == regex.Match(ext.FileName.ToString()).Value) select ext).Count() > 0)
            {
            }
        }
    }
    class extention
    {
        public string FileName { get; set; }
    }
    }
