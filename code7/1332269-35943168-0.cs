    void Main()
    {
    	var elements = GetElements(GetMyXml());
    	//elements.Dump();
    	var workingStorageVariables = GetWorkingStorageVariables(elements);
    	//workingStorageVariables.Dump();
    
    	var tree = new XElement("a",
    		workingStorageVariables
    			.Where(h => h.Level == 1)
    			.Select
    			(
    				h => new XElement("children", 
    						new XElement("b",
    							new XElement("levelNumber", h.LevelText),
    							new XElement("name", h.VariableName),
    							GetChildVariables(workingStorageVariables, h))
    				)
    			)
    	);
    
    	Console.WriteLine(tree);
    }
    
    public static string GetMyXml()
    {
    	return "<a>" +
    	"<b><levelNumber>01</levelNumber><name>top1</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2a</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2b</name></b>" +
    	"<b><levelNumber>10</levelNumber><name>lev3a</name></b>" +
    	"<b><levelNumber>10</levelNumber><name>lev3b</name></b>" +
    	"<b><levelNumber>10</levelNumber><name>lev3c</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2c</name></b>" +
    	"<b><levelNumber>10</levelNumber><name>lev3d</name></b>" +
    	"<b><levelNumber>01</levelNumber><name>top2</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2d</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2e</name></b>" +
    	"<b><levelNumber>05</levelNumber><name>lev2f</name></b>" +
    	"</a>";
    }
    
    public static IEnumerable<MyElement> GetElements(string xml)
    {
    	XDocument doc = XDocument.Parse(xml);
    
    	return doc.Root
    			  .Elements()
    			  .Elements()
    			  .Select(x => new MyElement
    			  {
    				  ElementName = x.Name.LocalName,
    				  ElementValue = x.Value
    			  });
    }
    
    public static IEnumerable<WorkingStorageVariable> GetWorkingStorageVariables(IEnumerable<MyElement> elements)
    {
    	List<WorkingStorageVariable> workingStorageVariables = new List<WorkingStorageVariable>();
    	
    	int level = 0;
    	string levelText = String.Empty;
    	string variableName = String.Empty;
    
    	foreach (var element in elements)
    	{
    		if (element.ElementName == "levelNumber")
    		{
    			levelText = element.ElementValue;
    			level = Convert.ToInt32(element.ElementValue);
    		}
    
    		if (level != 0 && element.ElementName == "name")
    		{
    			variableName = element.ElementValue;
    			workingStorageVariables.Add(new WorkingStorageVariable { Level = level, LevelText = levelText, VariableName = variableName });
    			level = 0;
    		}
    	}
    	
    	return workingStorageVariables;
    }
    
    public static IEnumerable<XElement> GetChildVariables(
    			IEnumerable<WorkingStorageVariable> workingStorageVariables,
    			WorkingStorageVariable parent)
    {
    	return
    		workingStorageVariables
    			.SkipWhile(h => h != parent)
    			.Skip(1)
    			.TakeWhile(h => h.Level > parent.Level)
    			.Select(h =>
    				new XElement("children",
    					new XElement("b",
    						new XElement("levelNumber", h.LevelText),
    						new XElement("Name", h.VariableName),
    						GetChildVariables(workingStorageVariables, h)
    					))
    			);
    }
    
    public class MyElement
    {
    	public string ElementName { get; set; }
    	public string ElementValue { get; set; }
    }
    
    public class WorkingStorageVariable
    {
    	public int Level { get; set; }
    	public string LevelText { get; set; }
    	public string VariableName { get; set; }
    }
