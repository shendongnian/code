    using QueryParams = System.Collections.Generic.List<QueryParam>;
    
    public class QueryParam {
        public string Parameter { get; set; }
    	public QueryParam(string para) {
    		Parameter = para;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var Qp = new QueryParams() {
    			new QueryParam("BUSINESS_CATEGORY"),
    			new QueryParam("CATEGORY")
    		};
    		string QpXml = ToXml(Qp);
    		// Use your XML from here on
    	}
    	
    	private static string ToXml(QueryParams Qp) {
    		StringBuilder Sb = new StringBuilder();
    		Sb.AppendLine("<typ:queryParams>");
    		foreach (var q in Qp) {
    			Sb.AppendLine("<typ:queryParam>");
    			Sb.AppendLine("<typ:parameter>" + q.Parameter + "</typ:parameter>");
    			Sb.AppendLine("</typ:queryParam>");
    		}
    		Sb.AppendLine("</typ:queryParams>");
    		return Sb.ToString();
    	}
    }
