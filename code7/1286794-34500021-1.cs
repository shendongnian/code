    static void Main(string[] args)
    {
            List<char> data = "1234567890".ToList();
            List<char> toDelete = new List<char>();
           
             for (int i = 0; i < data.Count; i++)
                toDelete.Add(data[i]);
            for (int i = 0; i < toDelete.Count; i++)
                data.Remove(toDelete[i]);
    }
