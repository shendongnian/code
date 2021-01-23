    public static ICollection<ObjectWithPriority> CreateObjectsWithPriorities()
    {
        IEnumerable<ObjectWithPriority> queryThatProducesObjectsWithPriorities = new[] { 1, 2, 3 }.Select(i => new ObjectWithPriority() { Id = i }); // just for clarification
        ICollection<ObjectWithPriority> objectsWithPriorities = queryThatProducesObjectsWithPriorities.ToList();
        ApplyPriorities(objectsWithPriorities);
        return objectsWithPriorities;
    }
    
    static void ApplyPriorities(ICollection<ObjectWithPriority> objs)
    {
        foreach (var obj in objs)
        {
            obj.Priority = obj.Id * 10;
            Console.WriteLine(String.Format("Set priority of object #{0} to {1}", obj.Id, obj.Priority));
        }
    }
