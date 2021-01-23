    public class CA : AC, IA, IB, IC
    {
        public override void getName(string s)
        {
            Console.WriteLine(s);
        }
        void IC.getName(string s)
        {
            // Your code
        }
        void IB.getName(string s)
        {
            // Your code
        }
        void IA.getName(string s)
        {
            // Your code
        }
    }
