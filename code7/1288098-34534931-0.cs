	using System.Text.RegularExpressions;
	...
	string mystr = "this is my very long text";
	mystr = Regex.Replace("(.{20})", "$1\n");
    TextBox1.Text = mystr; // or: TextBox1.Content = mystr;
