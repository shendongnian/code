            for (int i = 0; i < numCols && i < 26; i++)
            {
                char start = 'A';
                char colChar = (char)(start + (char)(i));
                Console.WriteLine(string.Format("{0}", colChar), typeof(string));
            }
            for (int i = 26; i < 52 && i < numCols; i++)
            {
                char start = 'A';
                char colChar = (char)(start + (char)(i-26));
                Console.WriteLine(string.Format("A{0}", colChar), typeof(string));
            }
