    public static void Main()
       {
          String[] values = { null, "160519", "9432.0", "16,667",
                              "   -322   ", "+4302", "(100);", "01FA", "11111", "1234", "1234-1234-1234" };
          foreach (var value in values) {
             int number;
    
             bool result = Int32.TryParse(value, out number);
             if (result == true)
             {
                Console.WriteLine("This input value is definitely not valid as it is a number.");         
             }
             else
             { 
                Console.WriteLine("Perhaps this can be a valid input value as it could not be parsed as integer.", 
                                   value == null ? "<null>" : value);
             }
          }
       }
