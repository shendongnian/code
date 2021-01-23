    void Main()
    {
	   string input = "0935;093F;0928;094B;0926;";
	   Regex rx = new Regex(@"([0-9A-Fa-f]{4});");
	   string output = rx.Replace(input, match => ((char)Int32.Parse(match.Groups[1].Value, NumberStyles.HexNumber)).ToString());
	   textBox2.Text = output;
    }
