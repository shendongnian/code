    class clsItem
    {
        //private static event delEventHandler _show;
        private delEventHandler _show;
        private int _price;
    
        public clsItem()  //Konstruktor
        {
            
        }
        
        public event delEventHandler Show
        {
            add { _show += value; }
            remove { _show -= value; }
        }
    
        public int Price
        {
            set
            {
                _price = value;
                _show.Invoke();  //trigger Event when Price was changed
            }
        }
    }
