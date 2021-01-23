    ` class Program
        {
            private static int[] a = new int[10]; //global int!!!
            static void Main(string[] args)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = i; //You need to assign a value!
                }
                
            }
        }`
