    var myAaa = new Aaa()
    {
        B = new Bbb() { Name = "someone", DateOfBirth = DateTime.Today.AddYears(-20) },
        Cccs = Enumerable.Repeat<Ccc>(new Ccc() { Age = 20, Name = "someone else" }, 42).ToList()
    };
    var MyAaaSerialized = System.Web.Helpers.Json.Encode(myAaa);
    var MyAaaDeserialized = System.Web.Helpers.Json.Decode<Aaa>(MyAaaSerialized);
    dynamic data = MyAaaDeserialized; 
    foreach (Ccc newCccs in data.Cccs)
    {
        Console.WriteLine($"{newCccs.Name}\t{newCccs.Age}");
    }
