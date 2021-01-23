    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        public static class Program
        {
            public static void RecurseCheckitems(CheckItems items)
            {
                List<Int32> l_deleteKeys = new List<Int32>();
                // Step 1: DFS - Down down down to the deepest level
                foreach (Int32 key in items.Keys)
                {
                    RecurseCheckitems(items[key]);
                }
                // Step 2: Extract all KEYS of Childelements having an AGE of at least 20
                foreach (Int32 key in items.Keys)
                {
                    l_deleteKeys.AddRange(DoCheckItems(items[key]));
                }
                // Step 3: Remove all extracted keys from the current Objecct
                foreach (Int32 deleteKey in l_deleteKeys)
                {
                    items.Remove(deleteKey);
                }
            }
            /// <summary>
            /// Helper-Function to extract the keys of Child-Elements having an age of at least 20
            /// </summary>
            /// <param name="item">Parent-Item to check</param>
            /// <returns>List of KEYS of Child-Elements having an Age of at least 20</returns>
            private static List<Int32> DoCheckItems(CheckItems item)
            {
                List<Int32> l = new List<Int32>();
                foreach (Int32 key in item.Keys)
                {
                    if (item[key].Age > 20)
                    {
                        l.Add(key);
                    }
                }
                return l;
            }
        }
        public sealed class CheckItems : Dictionary<Int32, CheckItems>
        {
            public Int32 Age { get; set; }
        }
    }
