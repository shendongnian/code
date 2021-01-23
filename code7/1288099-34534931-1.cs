	using System.Text.RegularExpressions;
	...
	string mystr = "this is my very long text";
	mystr = Regex.Replace(mystr, "(.{20})", "$1\n");
    TextBox1.Text = mystr; // or: TextBox1.Content = mystr;
