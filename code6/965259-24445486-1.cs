            List<Cardtable> cardtable = new List<Cardtable>();
            cardtable.Add(new Cardtable() { id = 1, cardno = "0001-1234-5678-9001" });
            cardtable.Add(new Cardtable() { id = 2, cardno = "0001-1234-5678-9002" });
            string search_string = "0001-1234-5678-9002";
            var result = from c in cardtable
                    where c.cardno.Replace("-", "") == search_string.Replace("-", "")
                    select c;
            foreach (Cardtable ct in result)
            {
                Console.WriteLine("{0}:{1}", ct.id, ct.cardno);
            }
