public class Range
{
	public DateTime Start { get; set; }
	public DateTime Stop { get; set; }
	public Range(DateTime start, DateTime stop)
	{
		Start = start;
		Stop = stop;
	}
}
void Main()
{
	List<Range> ranges = new List<Range>();
	ranges.Add(new Range(new DateTime(2019, 10, 1), new DateTime(2019, 10, 2)));
	ranges.Add(new Range(new DateTime(2019, 10, 2), new DateTime(2019, 10, 3)));
	ranges.Add(new Range(new DateTime(2019, 10, 1), new DateTime(2019, 10, 3)));
	ranges.Add(new Range(new DateTime(2019, 10, 4), new DateTime(2019, 10, 5)));
	ranges.Add(new Range(new DateTime(2019, 10, 6), new DateTime(2019, 10, 8)));
	ranges.Add(new Range(new DateTime(2019, 10, 5), new DateTime(2019, 10, 7)));
	ranges.Add(new Range(new DateTime(2019, 10, 9), new DateTime(2019, 10, 9)));
	var rangesOrdered = ranges.OrderBy(t => t.Start).ToList();
	var sets = new List<List<Range>>() { new List<Range>() {rangesOrdered[0]}};
	var IsOverlaping = new Func<Range, Range, bool>((a, b) => a.Start < b.Stop && b.Start < a.Stop);
	
	for (var i = 1; i < rangesOrdered.Count; i++)
	{
			if (IsOverlaping(sets.Last().OrderBy(s => s.Stop).Last(), rangesOrdered[i]))
			{
				sets.Last().Add(rangesOrdered[i]);
			}
			else
			{
				sets.Add(new List<Range>() {rangesOrdered[i]});
			}
	}
}
