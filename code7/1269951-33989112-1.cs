    var addedObjects = new List<MyObject>();
    var removedObjects = new List<MyObject>(existingObjects);
    var sameObjects = new List<MyObject>();
    foreach (var newObject in updatedObjects)
    {
    	int index = removedObjects.FindIndex(oldObject => oldObject.Ids.SequenceEqual(newObject.Ids));
    	if (index < 0)
    		addedObjects.Add(newObject);
    	else
    	{
    		removedObjects.RemoveAt(index);
    		sameObjects.Add(newObject);
    	}
    }
