    var original = list.First();
    var newObject = new Class1(){
            DateVal = original.DateVal,
            //Set other properties
        };
        newObject.DateVal = new DateTime(newObject.DateVal.Value.Year, 1, 1);
        list.Add(newObject);
