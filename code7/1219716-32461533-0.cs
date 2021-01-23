    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    public class Program
    {
       public static void Main (String[] args)
       {
           IList<Boolean> testCollection = new Collection<Boolean>();
           testCollection.Add(false);
           testCollection.Add(true);
           FillCollection(testCollection);
        
           for (int index = 0; index < testCollection.Count; index++)
           {
               if (testCollection[index])
               {
                   Console.WriteLine("testCollection[{0}] is true", index);
               }
               else
               {
                   Console.WriteLine("testCollection[{0}] is false", index);   
               }
           }
       }
    
       public static void FillCollection (IList<Boolean> collection)
       {
           Random random = new Random();
           for (int i = 0; i < 500; i++)
           {
               Boolean item = Convert.ToBoolean(random.Next(0, 2));
               collection.Add(item);
           }
       }
    }
