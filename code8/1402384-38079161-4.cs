    	public static void WriteListToExcel<T>(List<T> list, string fulllPath)
		{
			try
	        {
			    List<string> result = new List<string>();
			    result.Add(String.Join(String.Empty, typeof(T).GetProperties().Select(i => String.Format("{0}\t", i.Name)))); // Headers
			    result.AddRange(list.Select(i => String.Join("\t", i.GetType().GetProperties().Select(t => t.GetValue(i, null))))); // Lines
			    File.WriteAllLines(fulllPath, result);
            }
			catch (Exception e)
	        {
	            // Error do what you want....
	        }
		}
