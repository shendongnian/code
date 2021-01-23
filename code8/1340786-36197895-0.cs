    abstract class ClassAbstract{
        protected static int _myInteger {get;set;}
    }
    
    class Class01:ClassAbstract{
        public int MyInteger {
            get{return _myInteger;}
            set{ _myInteger=value;}
        }
    }
    
    class Class02:ClassAbstract{
        public int MyInteger {
            get{return _myInteger;}
            set{ _myInteger=value;}
        }
    }
    
    static class Program {
        public void Main(){
            Class01 one = new Class01();
            one.MyInteger = 16;
            Class02 two = new Class02();
            Console.WriteLine("Class two: {0}", two.MyInteger);
        }
    }
