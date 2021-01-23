    //Get the day of the week as an int:
    int dayOfWeek = (int)DateTime.Now.DayOfWeek + 1; //DayOfWeek is 0 based
    //Daclare object for a specific day:
    myDataObject newObject = new myDataObject();
    //Populate variables of newObject here.
    //Then add it with the int dayOfWeek as the Key to the DataByDay Dictionary.
    thisWeek.DataByDay.Add(dayOfWeek, newObject);
