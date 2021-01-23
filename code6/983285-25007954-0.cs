    var tempSomeObjects = new List<SomeObjects>();
    foreach(var fk in SomeObjects)
    {
        foreach(var k1 in lista)
        {
            foreach(var k2 in k1.listb)
            {
                foreach(var k3 in k2.listc)
                {
                    foreach(var k4 in k3.listd)
                    {
                        foreach(var k5 in k4.liste)
                        {
                            if ((k4.name1 + k5.name2) == fk)
                            {
                                tempSomeObjects.Add(new SomeObjects(k4.name1, k5.name2, string.Empty, "ww"));
                            }
                        }
                    }
                }
            }
        }
    } 
