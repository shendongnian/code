    // Just populating the teachers names
	var teachers = new List<string> { "Sarah", "Rivka", "Lea", "Rachel" };
	// You can change the following line to whatever line you want that produces array of XElement in that format.
	var teachersXElements = teachers.Select(teacher => new XElement("teacher_name", teacher));
	
	var myClass = new XElement("class",
            new XAttribute("room_id", 1),
            new XElement ("classArea",
                new XElement("teachers", teachersXElements) // Here the "Magic" happens; simple as that.
            )
	);
	
	Console.WriteLine(myClass.ToString());
