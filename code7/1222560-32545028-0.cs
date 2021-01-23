    static void Main(string[] args)
    {
        var inputList = new List<InputClass>();
        inputList.Add(new InputClass() { id = 1, text = "Item #1" });
        inputList.Add(new InputClass() { id = 2, text = "Item #2" });
        inputList.Add(new InputClass() { id = 3, text = "Item #3" });
        inputList.Add(new InputClass() { id = 4, text = "SubItem #1", parentId = 1 });
        inputList.Add(new InputClass() { id = 5, text = "SubItem #2", parentId = 1 });
        inputList.Add(new InputClass() { id = 6, text = "SubItem #3", parentId = 2 });
    
        var outputList = inputList
            .Where(i => !i.parentId.HasValue) // Just get the parents
            .Select(i => new OutputClass()
        {
            id = i.id,
            icon = i.icon,
            text = i.text,
            children = inputList
            .Where(x => x.parentId == i.id)
            .Select(x => new OutputClass()
            {
                id = x.id,
                icon = x.icon,
                text = x.text,
            }).ToList()
        }).ToList();
    
        
        foreach (var output in outputList)
        {
           Console.WriteLine(output.text);
           output.children.ForEach(c => Console.WriteLine($"\t {c.text}"));
        }
    
        Console.ReadLine();       
    }
