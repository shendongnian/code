    //Assuming that variable "task" is referencing the Task<object>
    Type taskReturnType = ((MethodInfo) call.MethodBase).ReturnType; //e.g. Task<int>
    var type = taskReturnType.GetGenericArguments()[0]; //get the result type, e.g. int
    var convert_method = this.GetType().GetMethod("Convert").MakeGenericMethod(type); //Get the closed version of the Convert method, e.g. Convert<int>
    var result = convert_method.Invoke(null, new object[] {task}); //Call the convert method and return the generic Task, e.g. Task<int>
