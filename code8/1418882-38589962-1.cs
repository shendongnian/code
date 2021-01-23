    using System;
    
    public delegate void delEventHandler();
    
    class clsItem
    {
        public event delEventHandler PriceChanged;
        private int  _price;
    
        public clsItem()  //Konstruktor
        {
            
        }
    
        public int Price
        {
            set { 
                  if(value!=_price) // Only trigger if the price is changed
                  {
                    _price = value;
                    if(PriceChanged!=null) // Only run if the event is handled
                    {
                        PriceChanged();
                    }
                  }
                }
        }   
    }       
    
    class Program
    {   
        static void Main()
        {
           clsItem myItem = new clsItem();
           myItem.PriceChanged += new delEventHandler(onPriceChanged);
           myItem.Price = 123;   //this should trigger Event "PriceChanged" and call the onPriceChanged method
        }
    
        //EventHandler 
        public static void onPriceChanged()
        {
            Console.WriteLine("Price was changed");
        }
    }
