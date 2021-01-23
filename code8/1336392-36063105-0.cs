            string b = Console.ReadLine();
            int detect;
            if (int.TryParse(b, out detect)) <-- Will filter out strings here
                for (int i = 0; i < size; i++)
                {
                    a[i] = detect;
                }
                int len = a.Length;
                Program pj = new Program();
                pj.programBExtension(a, len);
