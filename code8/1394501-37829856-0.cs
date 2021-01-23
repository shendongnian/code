    class Program
    {
        const string a = "Hello";
        const string b = "World";
        const string c = "Go";
        const string d = "Stay";
        const string e = "Stop"; 
        static void Main(string[] args)
        {
            Stack st = new Stack();
            st.Push(a);
            st.Push(b);
            st.Push(c);
            st.Push(d);
            st.Push(e);
            if ((st.Contains("Hello") || st.Contains("World")) && (st.Contains("Go") || st.Contains("Stay")) && (st.Contains("Stop") == false))
            {
                Console.WriteLine("Success");
            } // no success
            //Remove "Stop" to match the expression
            st.Pop();
            if ((st.Contains("Hello") || st.Contains("World")) && (st.Contains("Go") || st.Contains("Stay")) && (st.Contains("Stop") == false))
            {
                Console.WriteLine("Success");
            } //success
            Console.ReadLine();
        }
    }
