    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main ()
            {
                Hashtable french_numbers = new Hashtable ();
                french_numbers ["zero"] = 0;
                french_numbers["cinq"] = 5;
    
                Hashtable english_numbers = new Hashtable();
                english_numbers ["zero"] = 0;
                english_numbers ["five"] = 5;
    
                Console.WriteLine(Launcher.SearchHashTablesByKey (new List<Hashtable> () {
                    french_numbers,
                    english_numbers
                }, "five"));
    
                Console.ReadKey(true);
            }
    
            private static Object SearchHashTablesByKey (List<Hashtable> list, Object key)
            {
                foreach (Hashtable table in list)
                {
                    if (table.ContainsKey(key))
                    {
                        return table[key];
                    }
                }
                return null;
            }
        }
    }
