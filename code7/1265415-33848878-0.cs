    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable ThisProduction = new DataTable();
                datThisProduction.Columns.Add("IDColumn", typeof(int));
                datThisProduction.Columns.Add("DataColumn", typeof(int));
                init strThisID = 123;
                DataTable datThisProduction = ThisProduction.AsEnumerable()
                    .Where(x => x.Field<int>("IDColumn") == strThisID)
                    .OrderBy(y => y.Field<int>("DataColumn"))
                    .CopyToDataTable();
            }
        }
    }
