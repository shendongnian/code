    var l = new List<Foo>();
    foreach (line in lines)
    {
        var sp = line.Split(',');
        var foo = new Foo
        {
           Id = int.Parse(sp[0].Trim()),
           Date = sp[1].Trim(),//or pharse the date to a date time struct
           Cold = double.Parse(sp[2].Trim())
        }
        l.Add(foo);
    }
    //now l contains a list filled with Foo objects
