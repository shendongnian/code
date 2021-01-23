    string path = Path.Combine("D", "MyFile.csv");
    
    using (var dataContext = new MyDataContext())
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            StringBuilder line = new StringBuilder();
            foreach (var quickBook in dataContext.QuickBooks)
            {
                line.AppendFormat("{0};", quickBook.Name);
                // Append the other properties (remember the culture with the numbers)
    
                line.Clear();
                sw.WriteLine(line.ToString());
            }
        }
    }
