    // intended is not needed, but it makes it easier to know whats going on.
    var json = JsonConvert.SerializeObject(yourObject, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
