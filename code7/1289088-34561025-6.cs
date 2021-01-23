	using System.Text.RegularExpressions;
	...
	string searchstring = ....;
	string input = richTextBox1.Text;
	
	searchstring = string.Join("", searchstring.Select(c => "\\u" + ((ushort)c).ToString("x4"));
	
	int count = Regex.Matches(input, searchstring).Count;
	
	label1.Text = count.ToString();
