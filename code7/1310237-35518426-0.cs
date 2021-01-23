    using System.Data;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace TestExcelAddIn
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IStringGetter
        {
            string ExcelReturnString();
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class StringGetter : IStringGetter
        {
            public string ExcelReturnString()
            {
                return "This is the string: hi";
            }
        }
    }
