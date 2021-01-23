    //customer exception class
    public class QueryError : Exception{
    }
    [HttpGet]
    public IQueryable<myData> myData()
    {
       try{
            return _repo.myData();
       }catch(Exception e){
            throw new QueryError("An error occurred.");
            // not a good practice though, too much exceptions to handle for the system.
       }
    }
