    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataSet objDataSet = new DataSet();
                Dictionary<Int64, List<DataRow>> dict = objDataSet.Tables[0].AsEnumerable()
                    .GroupBy(x => x.Field<Int64>(0), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                foreach (var item in EU)
                {
                    Int64 itemKey = Convert.ToInt64(item.Substring(1, item.Length - 1));
                    if(dict.ContainsKey(itemKey))
                    {
                        List<DataRow> rows = dict[itemKey];
                        foreach (DataRow row in rows)
                        {
                            if (row[0].Field<bool>(1) == true)
                            {
                                ExistingPhones.Add(phoneWithoutPlus, true);
                            }
                            else
                            {
                                UpdatePhones.Add(phoneWithoutPlus, true);
                            }
                        }
                    }
                    else
                    {
                        ActivePhones.Add(itemKey, true);
                    }
                }
            }
        }
    }
    ​
