            var myObjects = new List<ObjectWrapper>();
            myObjects.Add(new ObjectWrapper<int>(3));
            myObjects.Add(new ObjectWrapper<decimal>(3.9m));
            myObjects.Add(new ObjectWrapper<DateTime> (DateTime.Now));
            myObjects.Add(new ObjectWrapper<string> ("HELLO"));
            var clone = Serializer.DeepClone(myObjects);
