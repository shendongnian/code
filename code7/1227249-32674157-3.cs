    public class Sample2
    {
        public void PrintI()
        {
            int i;  
            //Compile Error: Use of unassigned local variable 'i'
            Console.WriteLine(i.ToString());
        }
    }
