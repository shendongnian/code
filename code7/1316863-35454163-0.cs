    class Program
       {       
        static void Main(string[] args)
        {           
            test abbb = new test();
   
            Console.WriteLine(abbb.add(32767, 32770)); //short , int
            Console.WriteLine(abbb.add(32770, 32767)); //int ,short
            Console.WriteLine(abbb.add(255, 32770)); // byte,int
            Console.WriteLine(abbb.add(32770, 255)); // int,byte
            
            Console.ReadLine();
        }
    }
    class test
    {       
        public int add(byte f, int i)
        {
            return i + f;
        }
        public int add(int i, byte f)
        {
            return i + f;
        }
        public int add(short i, int f)
        {
            return i + f;
        }
        public int add(int f, short i)
        {
            return i + f;
        }
    }
