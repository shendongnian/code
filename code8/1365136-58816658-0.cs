         static void Main(string[] args)
         {
			string time1 = "11:15 AM";
			string time2 = "11:15 PM";
			var t1 = ConvertTimeToInt(time1);
			var t2 = ConvertTimeToInt(time2);
			Console.WriteLine("{0}", t1);
			Console.WriteLine("{0}", t2);
			Console.WriteLine("{0:dd/MM/yyyy hh:mm tt}", ConvertIntToTime(t1));
			Console.WriteLine("{0:dd/MM/yyyy hh:mm tt}", ConvertIntToTime(t2));
			Console.ReadLine();
        }
		static long ConvertTimeToInt(string input)
		{
			var date = DateTime.ParseExact(input, "hh:mm tt", CultureInfo.InvariantCulture);
			TimeSpan span = date.TimeOfDay;
			Console.WriteLine("{0:dd/MM/yyyy hh:mm tt}", date);
			return span.Ticks;
		}
		static DateTime ConvertIntToTime(long input)
		{
			TimeSpan span = TimeSpan.FromTicks(input);
			var date = new DateTime(span.Ticks);
			Console.WriteLine("{0:dd/MM/yyyy hh:mm tt}", date);
			return date;
		}
