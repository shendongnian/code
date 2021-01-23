	void Main()
	{
		string str = "This is a sample string";
		strOps obj = new strOps();
		strDelegate delRef = obj.removeSpaces;
		delRef += strOps.reverseString;
	
		delRef(str);
	}
	
	delegate string strDelegate(string str); 
	class strOps
	{
		public static string reverseString(string str)
		{
			string temp = string.Empty;
			for(int i=str.Length -1 ; i>=0 ; i--)
			{
				temp += str[i];
			}
			Console.WriteLine("Output from ReverseString: {0}", temp);
			return temp;
	
		}
	
		public string removeSpaces(string str)
		{
			string temp = string.Empty;
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] != ' ')
					temp += str[i];
			}
			Console.WriteLine("Output from RemoveSpaces: {0}", temp);
			return temp;
		}
	}
	
