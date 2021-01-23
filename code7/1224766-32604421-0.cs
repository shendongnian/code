    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                List<int> maximumLengthForColumns = new List<int>(dt.Columns.Count);
                foreach (DataRow row in dt.AsEnumerable())
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i].GetType() == typeof(string))
                        {
                            int length = row.Field<string>(i).Count();
                            if (length > maximumLengthForColumns[i])
                                maximumLengthForColumns[i] = length; 
                        }
                    }
                }
            }
        }
    }
    ​
