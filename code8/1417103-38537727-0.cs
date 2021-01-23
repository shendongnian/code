    class MyResultsController : ApiController {
        public IQueryable<MyResult> GetMyResults()
        {
            return db.MyLists.Select(x => new MyResult
            {
                Trade_Name = x.Trade_Name,
                price = x.price,
                remarks = x.remarks,
                Comment = x.Comment,
                GenericGroupNumber = x.GenericGroupNumber
            }); 
        }
    }
