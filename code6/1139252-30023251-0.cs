        public static void disposeComObject<T>(ref T comObject)
        {
           if(Marshal.IsComObject(comObject) && comObject != null)
           {
               //You need to save the object
               if(typeof(T) == typeof(Microsoft.Office.Interop.Excel.Workbook))
               {
                    ((Microsoft.Office.Interop.Excel.Workbook))comObject.Save();
                    ((Microsoft.Office.Interop.Excel.Workbook))comObject.Close();
               }
               //You need to save the object
               if(typeof(T) == typeof(Microsoft.Office.Interop.Excel.Application))
               {
                    ((Microsoft.Office.Interop.Excel.Application))comObject.Quit();
               }
               Marshal.ReleaseComObject(comObject);
               comObject = null;
           }
        }
