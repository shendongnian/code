    class Program
    {
        
    static void Main(string[] args)
    {
    var reader = new StreamReader(File.OpenRead(@"YourCSV"),Encoding.Unicode);
            
     List<Customer> customer = new List<Customer>();
    
     while (!reader.EndOfStream)
     {
        Customer c = new Customer
        {
            m_line1 = null,
            m_line2 = null,
        };
    
         var line = reader.ReadLine();
         var tokens = line.Split(',');
    
         c.m_line1 = tokens[0];
         c.m_line2 = tokens[1];
         customer.Add(c);
    
     }
    
       foreach(var s in customer)
       {
          Console.Writline(s);
          Console.Readline();
       }
    }
    }
      
  
    class Customer
    {
       private string line1;
       public string m_line1
       {
       get
       {
         return line1;
       }
      set
      {
        line1= value;
      }
    }
    
    private string line2;
    public string m_line2
    {
      get
      {
        return line2;
      }
    
      set
      {
        line2= value;
      }
    }
