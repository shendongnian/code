    var original = list.First();
    var newObject = new Class1(){
            DateVal = original.DateVal,
            //Set other properties
        };
        original.DateVal = new DateTime(original.DateVal.Value.Year, 1, 1);
        list.Add(newObject);
