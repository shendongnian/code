     string json = "[{\"id\":100,\"UserId\":99},{\"id\":101,\"UserId\":98}]";
            var objects = JArray.Parse(json);
            var firstIndexValue = objects[0];
            Console.WriteLine(firstIndexValue);
            foreach (var index in objects)
            {
                Console.WriteLine(index);
            }
    for (int index = 0; index < objects.Count; index++)
            {
                Console.WriteLine(objects[index]);
            }
