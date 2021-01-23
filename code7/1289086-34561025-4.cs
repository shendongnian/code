	using System.Text.RegularExpressions;
	...
	string searchstring = ....;
	string input = richTextBox1.Text;
	
	input = string.Join("", input.Select(c => "\\u" + ((ushort)c).ToString("x4"));
	
	int count = Regex.Matches(input, searchstring).Count;
	
	label1.Text = count.ToString();
