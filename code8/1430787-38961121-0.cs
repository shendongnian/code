    using System.Linq;
    var properties = Row.GetType().GetProperties().Where(p => !p.Name.EndsWith("_IsNull")).Select(p => p.Name).ToArray();
    foreach (var p in properties)
    {
        //Do Something
    }
