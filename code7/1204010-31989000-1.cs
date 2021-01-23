    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
	    {
    		string toConvert = "<BOLD_HTML_TAG>lorem ipsum is simply dummy</BOLD_HTML_TAG> text of the printing and typesetting industry."+
    				"<PARAGRAPH_TAG>LOREM ipsum has been the industry's standard dummy "+
    				"text ever since the 1500s</PARAGRAPH_TAG>.";
    		var sentenceRegex = new Regex(@"(?<=<(?<tag>\w+)>).*?(?=</\k<tag>>)", RegexOptions.ExplicitCapture);
    		var result = sentenceRegex.Replace(toConvert, s => s.Value.Substring(0,1).ToUpper()+s.Value.ToLower().Substring(1));
    		Console.WriteLine(toConvert + "\r\n" + result);
    	}
    }
