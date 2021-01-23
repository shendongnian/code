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
    /* returns:
    Name   Type Weight
    Fido   Dog  15.0
    Juliet Cat  12.0
    Juliet Fish 1.0
    */
	var filtered2 = animals.DistinctBy(a => a.Name); // or a simple property
    /* returns:
    Name   Type Weight
    Fido   Dog  15.0
    Trixie Dog  15.0
    Juliet Cat  12.0
    */
