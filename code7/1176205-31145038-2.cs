    string[] data = {"1","2","3","5","6","7","4"};
    var valueToChangeAt = 3;
    //The above should be parameters, and passed into this as a separate method
    Queue<String> tempHolder = new Queue<String>();
    for(var i = 0; i < data.Length; i++) {
        if(i >= valueToChangeAt-1)
            tempHolder.Enqueue(data[i]);
    }
    string[] newData = new string[data.Length+1];
    for(var j = 0; j < valueToChangeAt; j++)
        newData[j] = data[j];
    newData[valueToChangeAt-1] = "";
    for(var k = valueToChangeAt; k < newData.Length; k++)
        newData[k] = tempHolder.Dequeue();
    
    //At this point return newData, allowing your stack and old array to be destroyed.
