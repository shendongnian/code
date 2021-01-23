		string str = "Walked. Turned back. But why? And said \"Hello world. Damn this string splitting things!\" without a shame.";
		string[] words = null;
		using (TextFieldParser parser = new TextFieldParser(new StringReader(str))){
			parser.Delimiters = new string[] { " " };
			parser.HasFieldsEnclosedInQuotes = true;
			words = parser.ReadFields();				
		}    
