    using System.Collections.Generic;
    using System.Linq;
    
    namespace DesignPatterns
    {
        public class Multiton
        {
            //read-only dictionary to track multitons
            private static IDictionary<int, Multiton> _Tracker = new Dictionary<int, Multiton> { };
    
            private Multiton()
            {
            }
    
            public static Multiton GetInstance(int key)
            {
                //value to return
                Multiton item = null;
                
                //lock collection to prevent changes during operation
                lock (_Tracker)
                { 
                    //if value not found, create and add
                    if(!_Tracker.TryGetValue(key, out item))
                    {
                        item = new Multiton();
    
                        //calculate next key
                        int newIdent = _Tracker.Keys.Max() + 1;
    
                        //add item
                        _Tracker.Add(newIdent, item);
                    }
                }
                return item;
            }
        }
    }
