        private static void Main(string[] args)
        {
            string[] one;
            try
            {
                // 1. Hit F10 to step into debugging.
                one = new string[] { "1" }; //2. Drag arrow to this
                // 3. Hit f5.
                Enumerable.Range(1, 1)
                    .Where(x => one.Contains(x.ToString()));
            }
            catch (Exception exception)
            {
                Console.Write("BOOM!");
            }
        }
