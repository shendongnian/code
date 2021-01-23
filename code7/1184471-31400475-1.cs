    namespace ConsoleApplication2
    {
        
    class Program
        {
          
      static void Main(string[] args)
            {
              
      //create the first arraylist
    
                ArrayList arraylist1 = new ArrayList();
    
                arraylist1.Add(5);
    
                arraylist1.Add(7);
    
                //create the second arraylist
    
                ArrayList arraylist2 = new ArrayList();
    
                arraylist2.Add("Five");//add the single value at time to the arraylist
    
                arraylist2.Add("Seven");//add the single value at time to the arraylist
    
                //perform AddRange method
    
                arraylist1.AddRange(arraylist2);//adding the arraylist as bulk in another arraylist
    
                // Display the values.
    
                foreach (object i in arraylist1)//iterating the arraylist1 value to object
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
