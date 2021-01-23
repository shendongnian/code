        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<char> query = "Not what you might expect";
            string vowels = "aeiou";
            for (int i = 0; i < vowels.Length; i++)
            {
                Console.WriteLine("out: " + i);
                query = query.Where(c =>
                {
                    Console.WriteLine("inner: " + i);
                    return c != vowels[i];
                });
            }
            Console.WriteLine("before query");
            foreach (var c in query)
            {
                Console.WriteLine(c);
            }
            Console.Read();
        }
