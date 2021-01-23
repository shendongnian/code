    //...
    // Here you do your Json parse with you library:
    //Then you need to iterate into the object adding those name values into a HashSet:
    System.Collections.Generic.HashSet<String> names = new System.Collections.Generic.HashSet<string> ();
    foreach (string name in ITERATE_HERE) {
        if (names.Contains (name)) {
            throw new System.ArgumentException("The name value need to be unique.", "some rule");
        }
        names.Add (name);
    }
    //...
