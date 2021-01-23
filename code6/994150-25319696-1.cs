	void Main()
	{
		// your input
		String input = @@"<td class=""name""><a href=""/leagues/euw/633"">Apdo Dog2</a></td>";
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
		var result = sb.ToString(); // -> holds: "Apdo Dog2"
	}
