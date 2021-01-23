	using System.Text.RegularExpressions;
	...
	string searchstring = ....;
	string input = richTextBox1.Text;
	
	searchstring = Regex.Escape(searchstring);
	
	int count = Regex.Matches(input, searchstring, RegexOptions.IgnoreCase).Count;
	
	label1.Text = count.ToString();
