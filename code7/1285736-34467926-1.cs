    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    namespace WebApplication1.CentralFunctions
    {
        public class ExportToExcel<T>
        {
            private IEnumerable<T> data;
    
            public ExportToExcel(IEnumerable<T> inputCollection)
            {
                this.data = inputCollection;               
                // Run in Debug Mode (F5) and see results when clicking ActionLink.
                Debug.WriteLine("Object: {0}", data.GetType());
                Debug.WriteLine("RowCount: {0}", data.Count());
                // TODO: place my "export to excel" commands here.
            }    
        }
    }
