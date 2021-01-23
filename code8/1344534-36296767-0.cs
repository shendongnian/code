	public class TextChangeBench 
	{
		private void SaveFile(string[] tab)
		{
			string saveLocation = "sampleTextReworked.txt";
			StreamWriter sw = new StreamWriter(saveLocation);
			foreach (string s in tab)
			{
				sw.Write(s);
			}
			sw.Close();
		}
		private string ReadFile()
		{
			var stream = Android.App.Application.Context.Assets.Open("sampleText.txt");
			StreamReader sr = new StreamReader(stream);
			string text = sr.ReadToEnd();
			sr.Close();
			return text;
		}
		public void ChangeText()
		{
			try
			{
				File.Delete("sampleTextReworked.txt");
			}
			catch (FileNotFoundException e) { Console.WriteLine(e); }
			try
			{
				string text = ReadFile();
				char c;
				string[] newTab = new string[text.Length];
				for (int i = 0; i < text.Length; i++)
				{
					c = (char)text[i];
					if (Char.IsUpper(c))
					{
						newTab[i] = text[i].ToString().ToLower();
					}
					else if (Char.IsLower(c))
					{
						newTab[i] = text[i].ToString().ToUpper();
					}
					else
					{
						newTab[i] = text[i].ToString();
					}
				}
				SaveFile(newTab);
			}
			catch (Exception e) { Console.WriteLine("{0} ", e); }
		}
	}
