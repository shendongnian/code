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
			
			}
			// special case, close bracket
			else if (input[i].Equals('>')) {
				inside = false;
				continue;
			}
			
			// add if needed
			if (!inside)
					sb.Append(input[i]);
		}
		var result = sb.ToString(); // -> holds: "Hello"
	}
