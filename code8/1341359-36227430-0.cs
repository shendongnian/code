    public class Program
	{
		public static void Main(string[] args)
		{
			
			Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>> workHours = new Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>>
			{
				{
					DayOfWeek.Sunday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				},
				{
					DayOfWeek.Monday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				},
				{
					DayOfWeek.Tuesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				}
				,
				{
					DayOfWeek.Wednesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				}
				,
				{
					DayOfWeek.Thursday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				}
				,
				{
					DayOfWeek.Friday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				}
				,
				{
					DayOfWeek.Saturday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(8), TimeSpan.FromHours(12)),    //8AM-12PM
					   Tuple.Create(TimeSpan.FromHours(13), TimeSpan.FromHours(17))    //1PM-5PM
					}
				}
			};
			
			Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>> workHours1 = new Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>>
			{
				{
					DayOfWeek.Sunday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				},
				{
					DayOfWeek.Monday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				},
				{
					DayOfWeek.Tuesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				}
				,
				{
					DayOfWeek.Wednesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				}
				,
				{
					DayOfWeek.Thursday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				}
				,
				{
					DayOfWeek.Friday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				}
				,
				{
					DayOfWeek.Saturday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(9)),    //12AM-9AM
					   Tuple.Create(TimeSpan.FromHours(21), TimeSpan.FromHours(24))    //9PM-12AM
					}
				}
			};
			Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>> workHours2 = new Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>>
			{
				{
					DayOfWeek.Sunday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				},
				{
					DayOfWeek.Monday,  
					new[] {
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				},
				{
					DayOfWeek.Tuesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				}
				,
				{
					DayOfWeek.Wednesday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				}
				,
				{
					DayOfWeek.Thursday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				}
				,
				{
					DayOfWeek.Friday, 
					new[]{
					   Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				}
				,
				{
					DayOfWeek.Saturday, 
					new[]{
					  Tuple.Create(TimeSpan.FromHours(0), TimeSpan.FromHours(24))    //12AM-12AM
					}
				}
			};
			
			
			DateTime currDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			DateTime firstDateOfWeek = currDate.AddDays(-1 * (int)currDate.DayOfWeek);
			Console.WriteLine("First Date Of Week " + firstDateOfWeek);
			//this list will produce values of test case #1
			List<Tuple<DateTime, TimeSpan>> dailyWorkHours = workHours.SelectMany(kvp => kvp.Value, 
				(k, v) => Tuple.Create<DateTime, TimeSpan> ( 
					firstDateOfWeek.AddDays((int)k.Key).AddHours(v.Item1.Hours), 
					v.Item2 - v.Item1 
				)).ToList();
			foreach (var item in dailyWorkHours)
			{
				Console.WriteLine(item.Item1 + " " + item.Item2);
			}
			//handle Test case #2
			//Test case #3 is extension of test case #2
			List<Tuple<DateTime, TimeSpan>> finalWorkHours = new List<Tuple<DateTime, TimeSpan>>();
			finalWorkHours.Add(dailyWorkHours.First());
			
			//idea is to compare current item in dailyWorkHours 
			//with the previous item (that is currently in finalWorkHours)
			foreach (var item in dailyWorkHours)
			{
				if (dailyWorkHours.IndexOf(item) == 0)
				{
					continue;
				}
				Tuple<DateTime, TimeSpan> finalLast = finalWorkHours.Last();
				//handle Test case #2 merge last item in finalWorkHours with current item
				//if last item's time span added to last item's date and it equals to current item date
				if (DateTime.Compare(finalLast.Item1.AddHours(finalLast.Item2.TotalHours), item.Item1) == 0)
				{
					finalWorkHours.RemoveAt(finalWorkHours.Count - 1);
					finalWorkHours.Add(Tuple.Create(finalLast.Item1, finalLast.Item2.Add(item.Item2)));
				}
				else {
					finalWorkHours.Add(item);
				}
			}
			Console.WriteLine("Final work hours");
			foreach (var item in finalWorkHours)
			{
				Console.WriteLine(item.Item1 + " " + item.Item2.TotalHours + " hrs");
			}
			Console.ReadKey();
		}
	}
