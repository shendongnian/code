       class Program
       {
          static void Main(string[] args)
          {
             var list = new MySortedList();
    
             list[0.5] = "A";
             list[1.0] = "B";
             list[3.0] = "C";
    
             Console.WriteLine(list[-0.6]); // writes: A
             Console.WriteLine(list[0.1]); // writes: A
             Console.WriteLine(list[0.6]); // writes: B
             Console.WriteLine(list[1.1]); // writes: C
             Console.WriteLine(list[1.2]); // writes: C
             Console.WriteLine(list[4.0]); // writes: C
          }
       }
    
       class MySortedList : SortedList<double, string>
       {
          new public string this[double key]
          {
             get
             {
                List<double> keys = this.Keys.ToList();
                List<double> higherKeys = keys.Where(p => p > key).ToList();
                double newKey;
                if (higherKeys.Count > 0)
                {
                   newKey = higherKeys.Min();
                }
                else
                {
                   newKey = keys.Max();
                }
                return base[newKey];
             }
             set
             {
                base[key] = value;
             }
          }
       }
