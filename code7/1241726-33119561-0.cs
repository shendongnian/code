    // I haven't tested this, but it may work:
    ProjectController pc = Lookup.getDefault().lookup(typeof(ProjectController));
    // You could also just try it without the ".class" part (since "class" is reserved in C#):
    ProjectController pc = Lookup.getDefault().lookup(ProjectController);
    // Or, if you want the .NET reflection "proper" way to do what I *think* you're attempting:
    ProjectController pc = typeof(ProjectController).GetContructor(Type.EmptyTypes).Invoke(null);
    // Of course, that's just the same thing as this simple line, so I probably misunderstood:
    ProjectController pc = new ProjectController();
