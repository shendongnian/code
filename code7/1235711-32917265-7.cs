    public class Animal {
       public string Name { get; set; }
       public string AnimalType { get; set; }
       public decimal Weight { get; set; }
    }
	IEnumerable<Animal> animals = new List<Animal> {
		new Animal { Name = "Fido", AnimalType = "Dog", Weight = 15.0M },
		new Animal { Name = "Trixie", AnimalType = "Dog", Weight = 15.0M },
		new Animal { Name = "Juliet", AnimalType = "Cat", Weight = 12.0M },
		new Animal { Name = "Juliet", AnimalType = "Fish", Weight = 1.0M }
	};
	var filtered1 = animals.DistinctBy(a => new { a.AnimalType, a.Weight });
	var filtered2 = animals.DistinctBy(a => a.Name); // or a simple property
