            string file = @"
                Rows
                ...
                product.people
                product.people_good
                product.people_bad
                product.boy
                ...
                Rows";
            string[] s = file.Split(new string[] { "product." }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                sb.Append(((i > 0 && i < s.Length)? "$product." : "") + s[i]);                                            
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
