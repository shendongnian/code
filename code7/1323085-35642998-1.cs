    public class controller
    {
        public controller()
        {
           var stuff =  GetData();
        }
        private static async Task<List<object>> GetData()
        {
            IQueryable CurrentPermutation = null;
            var IQuerableList = new List<object>();
            foreach (var test in db.Permutations)
            {
                CurrentPermutation = qry.Application(test.Application)
                .add(() => qry.OperatingSystem(test.OperatingSystem))
                .add(() => qry.CustomerID(test.CustomerID))
                .add(() => qry.Version(test.Version));             
                var results = await CurrentPermutation.ToListAsync();
                IQuerableList.AddRange(results);
            }
            return IQuerableList;
        }
    }
