    int number;
    
    //check if the userId is an integer
    if(!int.TryParse(userId, out number)){
        Console.WriteLine("Please enter a valid interger!!");
        return;
    }  
    var beAddress = context.BusinessEntityAddress;
    //check for the userId exist in the DB
    var flag = beAddress.Any(a => a.Address.StateProvinceID == number);
    
    if(flag){
       //do something if the user exist
    }
    else{
       //do something else if the user doesn't exist
    } 
    
