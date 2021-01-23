        var x = Enum.GetValues(typeof(Food));
        var a = Enum.IsDefined(typeof(Food), "Apple");
        var b = Enum.IsDefined(typeof(Food), "2");
        var c = Enum.IsDefined(typeof(Food), 2);
        var d = Enum.IsDefined(typeof(Food), 4);
        var e = Enum.GetNames(typeof(Food)).Contains("Apple");
        var f = Enum.GetNames(typeof(Food)).Contains("2");
        //var f = Enum.GetNames(typeof(Food)).Contains(2); //won't compile...
