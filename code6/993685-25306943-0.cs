	void Main()
	{
		// your input
		String input = @"<p style=""margin: 15px 0px; padding: 0px; border: 0px; outline: 0px;"">Hello</p>";
		// temp variables
		StringBuilder sb = new StringBuilder();
		bool inside = false;
		bool delete = false;
		// analyze string
		for (int i = 0; i < input.Length; i++)
		{
			// Special case, start bracket
			if (input[i].Equals('<')) {	
				inside = true;
				delete = false;
			}
			// special case, close bracket
			else if (input[i].Equals('>')) {
				inside = false;
				delete = false;
			}
			// other letters
			else if (inside) {
				// Once you have a space, ignore the rest until closing bracket
				if (input[i].Equals(' '))
					delete = true;
			}	
			// add if needed
			if (!delete)
					sb.Append(input[i]);
		}
		var result = sb.ToString(); // -> holds: "<p>Hello</p>"
	}
