    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace columnmatch
    {
        internal class Program
        {
    
            private const string Ex1 = "2      IDE            WesternDigital    1000202273280";
            private const string Ex2 = "1      IDE            Seagate             500105249280 ";
            private const string Ex3 = "0      IDE            SAMSUNG SSD 830 Series  128034708480";
    
            private static void Main(string[] args)
            {
                var result = new List<MyModel>();
                result.Add(ParseItem(Ex1));
                result.Add(ParseItem(Ex2));
                result.Add(ParseItem(Ex3));
            }
    
            private static MyModel ParseItem(string example)
            {
                var columnSplit = example.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
    
                int index = -1;
                string interfaceType = string.Empty;
                long size = -1;
                string model = string.Empty;
    
                if (columnSplit.Count() == 4)
                {
                    //direct match (no spaces in input)
                    index = Convert.ToInt32(columnSplit[0]);
                    interfaceType = columnSplit[1];
                    model = columnSplit[2];
                    size = Convert.ToInt64(columnSplit[3]);
                }
                else
                {
                    string modelDescription = string.Empty;
    
                    for (int i = 0; i < columnSplit.Count(); i++)
                    {
                        if (i == 0)
                        {
                            index = Convert.ToInt32(columnSplit[i]);
                        }
                        else if (i == 1)
                        {
                            interfaceType = columnSplit[i];
                        }
                        else if (i == columnSplit.Count() - 1) //last
                        {
                            size = Convert.ToInt64(columnSplit[i]);
                        }
                        else
                        {
                            //build the model
                            modelDescription += columnSplit[i] + ' ';
                        }
                    }
    
                    model = modelDescription.TrimEnd();
                }
    
                var myItem = BuildResultItem(index, interfaceType, model, size);
                return myItem;
            }
    
            private static MyModel BuildResultItem(int index, string interfaceType, string model, long size)
            {
                var myItem = new MyModel
                {
                    Index = index,
                    InterfaceType = interfaceType,
                    Model = model,
                    Size = size
                };
    
                return myItem;
            }
    
            private class MyModel
            {
                public int Index { get; set; }
                public string InterfaceType { get; set; }
                public string Model { get; set; }
                public long Size { get; set; }
            }
        }
    }
