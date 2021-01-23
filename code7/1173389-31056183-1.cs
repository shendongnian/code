    // Load your 1GB of data.
    var data = ALotOfData.Load();
    // Create a new domain with the dynamic assembly.
    var domain = AppDomain.Create("Dynamic Assembly Domain");
    domain.Load("primary.dll"); // Assembly containing your primary code.
    domain.Load("mydll.dll");
    // Create the remote proxy.
    var remote = domine.CreateInstanceAndUnwrap("primary", "primary.RemoteControl");
    
    // Invoke the logic in the loaded dll.
    remote.Execute("mydll", "mydll.DLL", data);
    // Unload the domain.
    AppDomain.Unload(domain);
