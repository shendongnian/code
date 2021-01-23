    public class Program
    {
    	public static void Main(string[] args)
        {
            // modified string !
            // "!=" -> "<>"; CA -> 'CA'
         	string condition = "('69'='69' OR '69'='66' OR '69'='21' OR '69'='93') AND ('CA'='FL' OR 'CA'='WA') AND ('22'<>'31' AND '22'<>'19')";			
    		Console.WriteLine(TestCondition(condition));
            // print FALSE because ('CA'='FL' OR 'CA'='WA') is FALSE
        }
    	
    	public static bool TestCondition(string c)
    	{
    		var dt = new DataTable();
    		dt.Columns.Add("col");
    		dt.Rows.Add("row");
            // hack
            // c is constant and doesn't depend on dt columns
            // if there are any rows, c is TRUE
    		var rows = dt.Select(c);
    		return rows.Length > 0;
    	}
    }
