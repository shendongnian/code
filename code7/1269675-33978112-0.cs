    var chosenDate = datePicker.value;
    if(chosenDate.Month < DateTime.Now.Month){
         System.Environment.Exit(1);
    }
    else{
         //Do nothing
    }
