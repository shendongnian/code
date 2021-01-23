    void SomeMethod()
    {
        Shape circle = new Circle();
        Console.WriteLine(circle.closedPath);  // True
        Shape line = new Line();
        Console.WriteLine(line.closedPath);  // False
    }
