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
              id = data.id ; 
              BBBCodePartOne = ... ; 
              BBBCodePartTwo = ... ; 
         }
    
         public int id { get; set; }
         public string BBBCodePartOne { get; set; }
         public string BBBCodePartTwo { get; set; }
         public Data ToData() 
         {
             return new Data() { id = id,  BBBCode = BBBCodePartOne  + BBBCodePartTwo } ;
         }
    }
