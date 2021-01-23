        string[] names = new [] {"AAPL", "GOOG", "MSFT"};
		
		string url = String.Format("http://finance.yahoo.com/d/quotes.csv?s={0}&f=a", String.Join(",", names));
		WebRequest wrPrice = WebRequest.Create(url);
		WebResponse wResp = wrPrice.GetResponse();
		StreamReader sr = new StreamReader(wResp.GetResponseStream());
		double[] dCurrentPrice = new double[names.Length];
			
		int iLine = 0;
		while (!sr.EndOfStream)
		{
			double val;
			if (double.TryParse(sr.ReadLine(), 
								System.Globalization.NumberStyles.AllowDecimalPoint, 
								System.Globalization.CultureInfo.InvariantCulture, 
								out val))
			{
				dCurrentPrice[iLine++] = val;
			}
		}
		sr.Close();
				
		Array.ForEach(dCurrentPrice, x => Console.WriteLine(x));
		
		return;
 
 
