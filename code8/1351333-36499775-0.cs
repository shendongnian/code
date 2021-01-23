    JArray jGridModel = JArray.Parse(gridModel);
    // declare your output variable
    List<ClassName> colmodel = new List<ClassName>();
    // use var so it can accept any output type
    var outputObject = jGridModel.ToObject<List<ClassName>>();
    // check the type of the output
    if (outputObject is ClassName){
       colmodel.Add(outputObject);
    }
    else{
       colmodel = outputObject;
    }
    //colmodel is your output which is always a List<ClassName> type
