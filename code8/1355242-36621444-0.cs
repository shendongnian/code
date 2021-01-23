	public enum Day
	{
		Saturday,
		Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday
	}
	public static void ShowDay(Day CurrentDay)
	{
		if (CurrentDay == Day.Friday)
			Console.WriteLine("A vacation");
	}
	public static void Main(string[] args)
	{
		Day X;
		X = Day.Friday;
		ShowDay(X);
		ShowDay(Day.Friday);
	}
