    public class Data
    {
         public int id { get; set; }
         public string BBBCode { get; set; }
    }
    
    public class DataViewModel
    {
         public DataViewModel() 
         {
         }
         
         public DataViewModel(Data data) 
         {
              // Do the necessary mapping. 
         }
    
         public int id { get; set; }
         public string BBBCodePartOne { get; set; }
         public string BBBCodePartTwo { get; set; }
         public Data ToData() 
         {
             // Do the necessary mapping. 
         }
    }
