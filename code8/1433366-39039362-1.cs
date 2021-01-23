    object c1 = new C1 {Prop3 = "C1"};
    object c2 = new C2 {Prop3 = "C2"};
    object c3 = new C3 {Prop3 = "C3"};
    object c4 = new C4();
    Console.WriteLine(GetProperty<string>(c1, "Prop3")); //Prints C1
    Console.WriteLine(GetProperty<string>(c2, "Prop3")); //Prints C2
    Console.WriteLine(GetProperty<string>(c3, "Prop3")); //Prints C3
    Console.WriteLine(GetProperty<string>(c4, "Prop3")); // Throws an exception.
