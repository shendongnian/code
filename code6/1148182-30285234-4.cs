    container.RegisterCollection<Animal>(new[] {
        typeof(Cat), 
        typeof(Dog), 
        typeof(Pig)
    });
    // or using Auto-Registration
    container.RegisterCollection<Animal>(new [] {
        typeof(Animal).Assembly
    });
