    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
					
    public class Program
    {
	public static void Main()
	{
		// output would be set by earlier code
		var output = @"Profiles on interface Wi-Fi:
    Group policy profiles (read only)
    ---------------------------------
       <None>
      User profiles
      -------------
                All User Profile     : GuestFSN
                All User Profile     : CorporateWifi
                All User Profile     : ATT3122";
		
		var regex = new Regex(@"All User Profile[\s]+: (.*)");
		var resultList = new List<string>();
		
		foreach (Match match in regex.Matches(output))
		{
			resultList.Add(match.Groups[1].ToString());
		}
		
		Console.WriteLine(string.Join(", ", resultList));
	}
    }
