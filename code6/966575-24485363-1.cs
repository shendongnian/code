    abstract class Base 
    {
        public string name { get; set; }
    
        public void Print()
        {
            Console.WriteLine("{0}", name );
        }
    }
    class Telephone :Base , IPhone
     {
         public Telephone()
         {
              name = "name telephone";
         }
     }
    
     class MP3 : Base, IMP3
     {
          public MP3()
          {
              name = "name mp3";
          }
     }
    class telMp3 : Base, IMP3, IPhone
    {
         private Telephone _tel;
         private MP3 _mp3; 
         public telMp3()
          {
              name = "name telMp3";
          }
    }
