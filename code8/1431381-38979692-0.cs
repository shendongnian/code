            //...
            StringBuilder strBuilder = new StringBuilder();
            var max = Math.Max(Alist.Count, Blist.Count);
            for (int i = 0; i < max; ++i)
            {
                if (Alist.Count > i)
                    strBuilder.Append(Alist[i]);
                if (Blist.Count > i)
                    strBuilder.Append(Blist[i]);
            }
            var result = strBuilder.ToString();
            Console.WriteLine(result);
