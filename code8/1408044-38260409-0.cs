    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.Print(); //Output: Hello
            myClass.SetVariable();
            myClass.Print(); //Output: Test
            
        }
    }
    class MyClass
    {
        string MyGlobaleVariable = "Hello"; //my global variable
        public void SetVariable()
        {
            MyGlobaleVariable = "Test";
        }
        public void Print()
        {
            Console.WriteLine(MyGlobaleVariable);
        }
    }
