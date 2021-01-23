     string input = "t1326".Replace("t", "");
     if (input.Length == 3)
         input = "0" + input;
     string pattern = "HHmm";
     DateTime dt;
     DateTime.TryParseExact(input, pattern, null, 
         DateTimeStyles.None, out dt);
     Console.WriteLine(dt.ToString("h:m tt")); //outputs 1:26 PM
     string reverse = String.Format("t{0}",dt.ToString("HHmm"));
     Console.WriteLine(reverse); //outputs t1326
