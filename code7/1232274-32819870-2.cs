    public class MyClass {
       public int ID { get; set; }
    
       private DateTime _date;
       public DateTime Date
       {
           get
           {
              //do something with the date field here
              
              // you could add a number of days for example
              _date = _date.AddDays(4);          
     
               return _date;
           };
           set
           {
               _date = value;
           };
        }   
        public MyClass()
        {
             _date = DateTime.Now();
        }
    }
