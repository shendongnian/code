    private static List<MyIP> loadips() // changed return type to List<MyIP>
    {
        using (TextReader tr = new StreamReader("ips.txt"))
        {
            var l = new List<MyIP>();
            string line = null;
            while ((line = tr.ReadLine()) != null)
            {
                l.Add(new MyIP { IP = line });
            }
            return l; // return the list!
        }
    }
