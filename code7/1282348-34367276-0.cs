    string userChoice;
    string[] MonthsOfTheYear = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    
    int[] DaysOfTheMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    string[] DaysOfTheWeek = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    var weekdayIndex = 4;
    for (var index = 0; index < MonthsOfTheYear.Length; index++)
    {
        for (var day = 1; day <= DaysOfTheMonth[index]; day++)
        {
            Console.WriteLine(String.Format("{0} {1} {2}", DaysOfTheWeek[weekdayIndex++ % 7], MonthsOfTheYear[index], day));
        }
        Console.Write("Enter any key to display next month. Enter 'e' to exit "); // Ask user to choose an option 
        userChoice = Console.ReadLine();
        if (userChoice == "e" || userChoice == "E")
        {
            // Break the execution
            break;
        }
    }
 
