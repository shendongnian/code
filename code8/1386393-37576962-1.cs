    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BasicDataStorageApp
    {
        public class Model
        {
            private Item[] _items;
    
            public Item[] Items
            {
                get { return _items; }
                set { _items = value; }
            }
    
            public bool WriteItems(string filename, bool append)
            {
                if (_items != null)
                {
                    for (int i = 0; i < _items.Length; i++)
                    {
                        string str = _items[i].ToString();
                        FileHelper.WriteLine(str, filename, append);
                    }
    
                    return true;
                }
    
                return false;
            }
    
            public IEnumerable<string> ReadItems(string filename)
            {
                return FileHelper.ReadLines(filename);
            }
        }
    }
