    private static void Print<T>(IEnumerable<UnwoundItem<T>> items, Func<T, String> toString, Int32 level)
    {
        var indent = new String(' ', level * 4);
        foreach (var item in items)
        {
            Console.Write(indent);
            Console.WriteLine(toString(item.Item));
            Print(item.UnwoundSubItems, toString, level + 1);
        }
    }
...
    var grandChild = new Tag { Name = "GrandChild", Id = 3 };
    var grandChild2 = new Tag { Name = "GrandChild 2", Id = 33 };
    var child = new Tag { Name = "Child", Id = 2, Tagging = new List<Tagging> { new Tagging { ParentId = 2, ChildId = 3, ChildTag = grandChild } } };
    var child2 = new Tag { Name = "Child 2", Id = 22, Tagging = new List<Tagging> { new Tagging { ParentId = 2, ChildId = 33, ChildTag = grandChild2 } } };
    var parent = new Tag { Name = "Parent", Id = 1,
        Tagging = new List<Tagging> {
            new Tagging { ParentId = 1, ChildId = 2, ChildTag = child },
            new Tagging { ParentId = 1, ChildId = 2, ChildTag = child2 } }
    };
    var fromParent = EnumerableExtensions
        .UnwindMany(
            parent,
            item =>
                item?.Tagging?.Select(tagging => tagging.ChildTag));
    Console.WriteLine("Parent to child:");                
    Print(new[] { fromParent }, item => item.Name, 0);
