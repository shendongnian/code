    public class A
    {
        public A(ITester tester)
        {
            this.tester = tester;
        }
        public string foo(string value)
        {
            return this.tester.Test(value);
        }        
    }
