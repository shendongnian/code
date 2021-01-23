	public static void CreateText(string text)
	{
		if (text.Length <= 80)
		{
			var str = new StringBuilder();
			var count = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				int n;
				if (int.TryParse(text[i].ToString(), out n))
				{
					count.Append(text[i]);
				}
				else
				{
					if (String.IsNullOrEmpty(count.ToString()))
					{
						str.Append(text[i]);
					}
					else
					{
						for (int j = 0; j < Convert.ToInt32(count); j++)
						{
							str.Append(text[i].ToString());
						}
						count.Clear();
					}
				}
			}
			Console.WriteLine(str);
		}
		else
		{
			Console.WriteLine("Error");
		}
	}
	
