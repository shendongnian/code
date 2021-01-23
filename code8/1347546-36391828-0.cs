    List<object> listOfObjects = new List<object>();
    listOfObjects.Add(new List<int>() { 1, 2, 3 }); // Adding list of int
    listOfObjects.Add("text"); // Adding string
    listOfObjects.Add(new float[] { 1.42f, 51.7f}); // Adding array of float
    listOfObjects.AddRange(listOfObjects); // Duplicating all the elements of listOfObjects
    listOfObjects.AddRange(listOfLists); // Adding all elments of the list listOfLists
