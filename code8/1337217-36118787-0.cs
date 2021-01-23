    //reference an accessible type to get the assembly fast and easy
    var asm = typeof (Microsoft.TeamFoundation.Build.Controls.AzureEditor).Assembly;
    //get the desired type
    var type = asm.GetTypes().Single(x => x.Name == "ServerFileBrowserEditor");
    //get the constructor
    var ctor = type.GetConstructor(Type.EmptyTypes);
    //create the object by invoking the constructor
    var obj = ctor.Invoke(null);
