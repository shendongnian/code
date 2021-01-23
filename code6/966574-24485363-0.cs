    abstract class Base 
    {
        public string name { get; set; }
    
        public void Print()
        {
            Console.WriteLine("{0}", name );
        }
    }
    class Telephone :Base 
     {
         public Telephone()
         {
              name = "name telephone";
         }
     }
    
     class MP3 : Base
     {
          public MP3()
          {
              name = "name mp3";
          }
     }
