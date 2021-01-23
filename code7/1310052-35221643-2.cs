    return new[]
    {
        new {
    		Namespace = GetPath(type.Namespace),
        	ActionName= actionName.Name,
        	Controller = type.Name.Remove(2);
        },
        new {
        	Namespace = "Some other value",
        	ActionName= "some other action name",
        	Controller= "some other controller name",
        }
    };
