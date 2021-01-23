      public static string Encode(string txt)
      {
		  string result = string.Empty;
		  foreach (char ch in txt)
		  {
			  // "tku" will be our delimiter
			  result += Convert.ToString((int)ch, 10) + "tku";;
		  }
		  result = result.Replace("0", "dos");
		  result = result.Replace("1", "vso");
		  result = result.Replace("2", "otw");
		  result = result.Replace("3", "foa");
		  result = result.Replace("4", "bae");
		  result = result.Replace("5", "xgd");
		  result = result.Replace("6", "ymt");
		  result = result.Replace("7", "ksx");
		  result = result.Replace("8", "wte");
		  result = result.Replace("9", "rom");
		  Console.WriteLine(result);
		  return result;
        }
 
        public static string Decode(string txt)
        {
            string result = txt;
            result = result.Replace("dos", "0");
            result = result.Replace("vso", "1");
            result = result.Replace("otw", "2");
            result = result.Replace("foa", "3");
            result = result.Replace("bae", "4");
            result = result.Replace("xgd", "5");
            result = result.Replace("ymt", "6");
            result = result.Replace("ksx", "7");
            result = result.Replace("wte", "8");
            result = result.Replace("rom", "9");
			// "tku" will be converted to spaces
            result = result.Replace("tku", " ");
			string result2 = string.Empty;
			// and we split over them
			foreach(var res in result.Split(' '))
			{
			  if(!String.IsNullOrWhiteSpace(res))
			  {
  			    result2 += ((char)Int32.Parse(res)).ToString();
			  }
			}			
            return result2;
        }
