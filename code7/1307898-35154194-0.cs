public class Apple
{
	public int Id { get; set; }
	public string Name { get; set; }
}
public class Worm
{
	public int AppleId { get; set; }
	public int WormType { get; set; }
	public int HungerValue { get; set; }
}
void Main()
{
	var apples = Enumerable.Range(1, 9).Select(e => new Apple { Id = e, Name = "Apple_" + e}).ToList();
	var worms = Enumerable.Range(1, 9).SelectMany(a =>
		Enumerable.Range(1, 5).Select((e, i) => new Worm { AppleId = a, WormType = e, HungerValue = i %2 == 0 ? a * e * 20 : 100 })).ToList();
	DoLINQ(apples, worms, "Apple_4", new[] {4, 5});
}
public void DoLINQ(IList<Apple> apples, IList<Worm> worms, string targetAppleName, IList<int> wormTypes)
{
	// Write LINQ Query here
	var result = apples.Where(a => 
		a.Name == targetAppleName &&
		(worms.All(w => w.AppleId != a.Id) || worms.Any(w => w.AppleId == a.Id && w.HungerValue >= 500)));
	result.Dump();  // remark this out if you're not using LINQPad
	
	apples.Dump();  // remark this out if you're not using LINQPad
	worms.Dump();   // remark this out if you're not using LINQPad
}
