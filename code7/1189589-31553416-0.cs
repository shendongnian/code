    static void WriteMessageOriginal(string name, int age)
    {
        Console.WriteLine("hi " + name + " i K=know u have " + age + " year old");
    }
    static void WriteMessageNew(string name, int age)
    {
        Console.WriteLine("hi {0}, I know you are {1} years old", name, age);
    }
