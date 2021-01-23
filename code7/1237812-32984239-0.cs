    bool repeat = true;
    var dblMilesMon = (double)0;
    do 
    {
    	Console.WriteLine("Enter value for Monday : ");
    	var strMilesMon = Console.ReadLine();
    	if (!double.TryParse(strMilesMon, out dblMilesMon))	
    		Console.WriteLine("You entered an invalid number - please enter a numeric value.")			
    	else
    		repeat = false;	
    }while (repeat);
    
    //do something with dblMilesMon
