    public class Animal
    {
        public int ID { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
    }
    ...
 
    IObservable<Animal> animals = ...;
    ITrackableObservable<Animal> trackableAnimals = animals.ToTrackableObservable();
    trackableAnimals
        .ObserveWhere(a => a.Kind == "Cat")
        .Subscribe(a => Console.WriteLine("{0}: Meow", a.ID));
    trackableAnimals
        .ObserveWhere(a => a.Kind == "Dog")
        .Subscribe(a => Console.WriteLine("{0}: Woof", a.ID));
    trackableAnimals
        .ObserveWhere(a => a.Name != null)
        .Subscribe(a => Console.WriteLine("{0}: {1}", a.ID, a.Name));
    trackableAnimals
        .Unobserved
        .Subscribe(a => Console.WriteLine("{0}: A nameless {1} was unobserved.", a.ID, a.Kind));
