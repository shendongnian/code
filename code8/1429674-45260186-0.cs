    #addin "Cake.Plist"
    
    Task("update-ios-version")
        .Does(() =>
        {
            var plist = File("./src/Demo/Info.plist");
            var data = DeserializePlist(plist);
    
            var itemPropertyInfo = data.GetType().GetProperty("Item");
            itemPropertyInfo.SetValue(data, gitVersion.AssemblySemVer, new[] { "CFBundleShortVersionString" });
            itemPropertyInfo.SetValue(data, gitVersion.FullSemVer, new[] { "CFBundleVersion" });
    
            SerializePlist(plist, data);
        });
