    var classRoom = new ClassRoom();
    // Think about how internally this just happened in ClassRoom's constuctor... 
    // Students = { "Mike", "Johny", "Vlad", "Stas" }
    // Note that the constructor could also have just done this...
    // _student = { "Mike", "Johny", "Vlad", "Stas" }
    // For instance this will print 4...
    Console.WriteLine(classRoom.Students.Count);
    // Manipulate Students collection...
    // We don't need access to the _students backing field here (getter-only Students property is fine)
    classRoom.Students.Remove("Vlad");
    classRoom.Students.Add("Vladislav");
    // This results in a compile time error due to the absence of a public getter.
    // This is right if intent was to only ever allow manipulation of the list and not replacement of the list instance (reference type).
    classRoom.Students = new List<string>();
