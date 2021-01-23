    var fields = new List<string>
    {
    	"DTSupplyAccountable",
    	"DTSupplyLeadResponsible",
    	"Author",
    	"Editor",
    	"ID"
    };
    
    var viewXml = new StringBuilder();
    
    viewXml.AppendLine("<ViewFields>");
    foreach (var field in fields)
    {
    	viewXml.AppendFormat("<FieldRef Name=\"{0}\" />", field).AppendLine();
    }
    viewXml.AppendLine("</ViewFields>");
    
    viewXml.AppendLine("<Query><Where><Eq><FieldRef Name=\"ContentType\" /><Value Type=\"Computed\">I-Demand</Value></Eq></Where></Query>");
    
    var camlQuery = new CamlQuery {ViewXml = string.Format("<View Scope=\"RecursiveAll\">{0}</View>", viewXml)};
    
    List<ListItem> results;
    
    using (var clientContext = GetClientContext())
    {
    	var list = clientContext.Web.Lists.GetByTitle("Demands");
    	var listItems = list.GetItems(camlQuery);
    	clientContext.Load(listItems);
    	clientContext.ExecuteQuery();
    	results = listItems.ToList();
    }
