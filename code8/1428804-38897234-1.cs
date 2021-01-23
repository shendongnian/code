    void Main()
    {
    	var myData = ReadMyCSV(@"c:\MyPath\MyFile.csv");
    	// do whatever with myData
    }
    
    public IEnumerable<MyRow> ReadMyCSV(string fileName)
    {
    	using (TextFieldParser tfp = new TextFieldParser(fileName))
    	{
    		tfp.HasFieldsEnclosedInQuotes = true;
    		tfp.SetDelimiters(new string[] { "," });
    
    		//tfp.CommentTokens = new string[] { "*","--","//" };
    		// instead of using comment tokens we are going to skip 4 lines
    		for (int j = 0; j < 4; j++)
    		{
    			tfp.ReadLine();
    		}
    
    		// header line.
    		tfp.ReadLine();
    
    		DateTime dt;
    		int i;
    		decimal d;
    
    		while (!tfp.EndOfData)
    		{
    			var data = tfp.ReadFields();
    
    			yield return new MyRow
    			{
    				MyCharData = data[0],
    				MyDateTime = DateTime.TryParse(data[1], out dt) ? dt : (DateTime?)null,
    				MyIntData = int.TryParse(data[2], out i) ? i : 0,
    				MyDecimal = decimal.TryParse(data[3], System.Globalization.NumberStyles.Any, null, out d) ? d : 0M
    			};
    		}
    	}
    }
    
    public class MyRow
    {
    	public string MyCharData { get; set; }
    	public int MyIntData { get; set; }
    	public DateTime? MyDateTime { get; set; }
    	public decimal MyDecimal { get; set; }
    }
