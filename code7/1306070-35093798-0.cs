    // in QueryService.cs, you define a library for querying...
    public class QueryService
    {
	    public DataTable PerformQuery(string searchTerm)
	    {
	       // your query logic goes here. Return a logical result like a DataTable, some JSON, etc.
	    } 
    }   
    // in Query.ashx, call your query service;
    public void ProcessRequest(HttpContext context)
    {
        var searchTerm = context.Request.QueryString["query"];
        var results = new QueryService().PerformQuery(searchTerm);
        context.Response.Write(...results...);
    }
    // in Start.ashx, call your query service again;
    public void ProcessRequest(HttpContext context)
    {
        var searchTerm = context.QueryString["homepage"];
        var results = new QueryService().PerformQuery(searchTerm);
        context.Response.Write(...results...);
    }     
