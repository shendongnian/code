	public class Animal
	{
		public string Colour { get; set; }
		public int Weight { get; set; }
		public Animal(Dog data) : this (data.Colour, data.Weight)
		{
		}
		public Animal(Cat data) : this (data.Colour, data.Weight)
		{
		}
		private Animal(string colour, int weight)
		{
		    this.Colour = colour;
		    this.Weight = weight;
		}
	}
