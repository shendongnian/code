            List<String> lstResults1 = new List<string>();
            List<int> lstResults2 = new List<int>();
            lstResults1.Clear();
            lstResults2.Clear();
            string[] strings = { "book", "zebra" };
            string subtrResult = strings[0].Substring(0, 1);
            var substCompare = String.Compare((strings[1].Substring(0, 1)), "n");
            lstResults1.Add(subtrResult);
            lstResults2.Add(substCompare);
            var AM =
                from x in strings
                where (String.Compare((x.Substring(0, 1)), "n")) < 0
                select x;
            var NZ =
                from x in strings
                where !AM.Contains(x)
                select x;
