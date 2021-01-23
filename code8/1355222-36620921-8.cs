    using (var myObject = new Func<Something>(() =>
                        {
                            var myNewObject = new Something();
                            PopulateSomethingObject(myNewObject);
                            return myNewObject;
                        }).Invoke())
    {
        //x = myObject.SomeNumber();
    }
