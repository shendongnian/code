	var result = new StringBuilder();
	
	for (int i = 0; i < first_richtextbox.Text.Length; i++)
	{
		if (dictionary.ContainsKey(text[i]))
		{
			result.Append(dictionary[text[i]]);
		}
		else 
		{
			result.Append(text[i]);
		}
	}
	
	second_richtextbox.Text = result.ToString();
