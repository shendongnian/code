    var chosenDate = datePicker.Value;
    if(chosenDate.Month < DateTime.Now.Month){
         System.Environment.Exit(1);
    }
    else{
         //Do nothing
    }
