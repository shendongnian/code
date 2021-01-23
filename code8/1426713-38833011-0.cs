    public class CharWithPadding
    {
    	public char Char;
    	public int Padding;
    }
...
    //Populate a list with the current date, and default padding
    var paddingDictionary = DateTime.Now.ToString("dd MM yyyy")
    	.ToCharArray()
    	.Select(c => new CharWithPadding { Char = c, Padding = 2 })
    	.ToList();
    
    //Add extra padding to specific point in the date-string
    paddingDictionary[2].Padding = 10;
    
    var output = string.Join("", paddingDictionary.Select(cwp => cwp.Char + new string(' ', cwp.Padding)));
