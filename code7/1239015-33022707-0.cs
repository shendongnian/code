    public class Program
    {
        public static void Main(string[] args)
        {
            var c1 = new Class1();
            
            c1.DoStuff();
        }
    }
    
    public class Class1
    {
        public void DoStuff()
        {
            var c = new Class2("stuff");
            
            var c2 = new Class2();
            c2.AcceptStuff("stuff2");
            
            c.Print();
            c2.Print();
            
            c2.MyData = "stuff3";
            c2.Print();
        }
    }
    
    public class Class2
    {     
        private string _myData;
        
        public Class2() 
        {
            
        }
        
        public Class2(string myData)
        {
            _myData = myData;
        }        
        
        public string MyData
        {
            set { _myData = value;}
        }
        public void AcceptStuff(string myData)
        {
            _myData = myData;
        }
        
        public void Print()
        {
            Console.WriteLine(_myData);
        }
    }
