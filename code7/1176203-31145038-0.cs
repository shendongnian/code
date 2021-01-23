    string[] data = {"1","2","3","5","6","7","4"};
    var valueToChangeAt = 5;
    //The above should be parameters, and passed into this as a separate method
    Stack tempHolder = new Stack();
    for(var i = 0; i < data.Count; i++) {
        if(i > valueToChangeAt)
            tempHolder.Push(data[i]);
    }
    string[] newData = new string[data.Count+1];
    for(var j = 0; j < valueToChangeAt; j++)
        newData[j] = data[j];
    newData[valueToChangeAt] = "";
    for(var k = valueToChangeAt+1; k < data.Count; k++)
        newData[j] = tempHolder.Pop(); 
    
    //At this point return newData, allowing your stack and old array to be destroyed.
