        public static void Main(string[] args)
        {
            var src = new List<int>() { 1, 2, 3, 4 };
            var q = src.Where(i =>
            {
                Output();
                return i % 2 == 1;
            }
            );
            IEnumerable<int> nl = src;
            var enmLinq = q.GetEnumerator();
            var enmNonLinq = nl.GetEnumerator();
            src.Add(5); //both enumerators should be invalid, as underlying data source changed     
            try
            {
                //throws as expected
                enmNonLinq.MoveNext();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("non LINQ enumerator threw...");
            }
            try
            {
                //DOES NOT throw as expected
                // Output() is called now.
                enmLinq.MoveNext();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("enumerator from LINQ threw...");
            }
            //It seems that if we want enmLinq to throw exception as expected:
            //we must at least once call MoveNext on it (before modification)
            enmLinq.MoveNext();
            src.Add(6);
            enmLinq.MoveNext(); // now it throws as it should
        }
        public static void Output()
        {
            Console.WriteLine("Test");
        }
