    public class SumStorage
    {
        // ...
        public List<SumOfAmounts> Sums { get; set; }
        // ...
        public SumStorage(File file, WebService webSvc)
        {
            Sums = new List<SumOfAmounts>();
            foreach(var row in file.radky)
            {
                var webRow = webSvc.radky.FirstOrDefault(x => x.NAME == row.NAME);
                if(webRow != null)
                    Sums.Add(new SumOfAmounts(row, webRow));
            }
        }
    }
