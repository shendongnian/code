    // Simple Injector v3.x
    container.RegisterCollection<Animal>(new[] {
        typeof(Cat), 
        typeof(Dog), 
        typeof(Pig)
    });
    // or
    container.RegisterCollection<Animal>(new [] {
        typeof(Animal).Assembly
});
    // Simple Injector v2.x
    container.RegisterAll<Animal>(new[] {
        typeof(Cat), 
        typeof(Dog), 
        typeof(Pig)
    });
