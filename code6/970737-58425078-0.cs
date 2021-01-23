    public class ReportsController : ODataController
    {
    	[EnableQuery]
    	[ODataRoute("Reports({id}, {year})")]
    	public IQueryable<ReportModel> Get([FromODataUri] int id, [FromODataUri] int year)
    	{
    		...
    	}
    }
