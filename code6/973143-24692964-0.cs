    string path = Path.Combine("D", "MyFile.csv");
    
    using (var dataContext = new MyDataContext())
    {
        using (StreamReader stream = new StreamReader(path))
        {
            string line;
    
            while ((line = stream.ReadLine()) != null)
            {
                string[] columns = stream.ReadLine().Split(';');
    
                QuickBook item = new QuickBook();
                item.Name = columns[0];
                // And so on with the other properties...
    
                dataContext.QuickBooks.Add(item);
            }
        }
    
        dataContext.SaveChanges();
    }
