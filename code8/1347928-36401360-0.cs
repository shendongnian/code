    class Student
    {
        private int _ID;
    
        public int ID( )
        {
            get{ return _ID;}
             
            set {
                if (value <= 0)
                    throw new Exception("It is not a Valid ID");
                _ID = value;
               }
    
        }
    
      
    }
    
    class Program
    {
        public static void Main()
        {
            Student C1 = new Student();
            C1.ID=101;
            Console.WriteLine("Student ID = {0}", C1.ID);
        }
    }
