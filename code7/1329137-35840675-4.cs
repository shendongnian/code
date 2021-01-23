    class AClass
    {
        string a = "Hello World";
        
        public void SomeMethod()
        {
            Action lambda = () => Console.WriteLine(a);
            lambda();
        }
    }
