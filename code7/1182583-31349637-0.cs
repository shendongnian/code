    var mcp1 = dotMemory.Check();
    methodX();
    dotMemory.Check(memory =>
    {
      var newObjects = memory.GetDifference(mcp1).GetNewObject();
      var createdObjectsCount = newObjects.ObjectsCount;
      var allocatedMemory = newObjects.SizeInBytes;
    });
