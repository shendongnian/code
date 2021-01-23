	void Main()
	{
		
		int test = 21;
		
		var allAnimals = (Animal[]) Enum.GetValues(typeof(Animal));
		var ordered = allAnimals.OrderByDescending(x => x);
		
		var animals = ordered.Aggregate(new List<Animal>(), (agg, ani) => { 
			if (test > 0) {
				int number = (int)(test / (int)ani);
				agg.AddRange(Enumerable.Repeat(ani, number));
				test -= number * (int)ani;
			}
			return agg;
		});
			
		Console.WriteLine(string.Join(", ", animals.Select(a=>a.ToString())));
	}
	[Flags]
    public enum Animal
    {
        Cow = 1,
        Duck = 2,
        Goose = 4
    }
	
