    //Get the day of the week as an int:
    int dayOfWeek = (int)DateTime.Now.DayOfWeek + 1; //DayOfWeek is 0 based
    //Daclare object for a specific day:
    myDataObject newObject = new myDataObject();
    //Populate variables of newObject here.
    thisWeek.DataByDay.Add(dayOfWeek, newObject);
