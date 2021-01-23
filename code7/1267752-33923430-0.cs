    do
    {
	  Console.Write("PLease enter the year (not earlier than 1812) as 4 digits  >> ");
    } while (!int.TryParse(Console.ReadLine(), out y) || y < 1812);
    do
    {
	  Console.Write("Please enter the month as a three letter character ( e.g 'Jul'>> ");
    }	while (!isCorrectMonth(Console.ReadLine()) );		
			
			
			
			
			
    static bool isCorrectMonth(string monthToCheck)
    {
	  string stringToCheck = monthToCheck.ToLower();
	  string[] stringArray = { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
	  foreach (string x in stringArray)
	  {
		if (x.Contains(stringToCheck))
		{
			// Process..
			return true;
		}
		else
		{
			return false;
		}
	  }
	  return false;
    }			
