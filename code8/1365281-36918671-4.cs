    public class GetResultsQueryHandler
    : IQueryHandler<FilterObject, YourModel>
    {
        public GetResultsQueryHandler([pass your needed dependencies here])
        {
            //set them to local variables
        }
 
        public YourModel Handle(FilterObject filterObject)
        {
           // Logic to call GetResults(filterObject) and return the filled model
        }
    }
