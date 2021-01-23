    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BasicDataStorageApp
    {
        public class Item
        {
            private int _number;
    
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }
    
            private string _description;
    
            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }
    
            public Item(int number, string description)
                : this()
            {
                _number = number;
                _description = description;
            }
    
            public Item()
            {
            }
    
            public override string ToString()
            {
                return string.Format("Item number {0} Description {1}", _number, _description);
            }
        }
    }
