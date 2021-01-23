    abstract class BaseDevice 
    {
        public string name { get; set; }
    
        public void Print()
        {
            Console.WriteLine("{0}", name );
        }
    }
    public interface IPhone
    {
       void DoPhone();
    }
    public interface IMP3
    {
        void DoMP3();
    }
    class Telephone :BaseDevice , IPhone
     {
         public Telephone()
         {
              name = "name telephone";
         }
     }
    
     class MP3 : BaseDevice , IMP3
     {
          public MP3()
          {
              name = "name mp3";
          }
     }
    class telMp3 : BaseDevice , IMP3, IPhone
    {
         private Telephone _tel;
         private MP3 _mp3; 
         public telMp3()
          {
              name = "name telMp3";
          }
         public  void DoPhone()
         {
             _tel.DoPhone();
         }
         public  void DoMP3()
         {
             _mp3.DoMP3();
         }
         
        
    }
