    while (counter < arraySize){
    	inValue = Console.ReadLine();
    	while (true){
    		if(double.TryParse(inValue ,out intValue) {
    			if(intValue >=1 && intValue <=10){
    				break;
    			}else{						
    				Console.WriteLine("Input must be in the range 1-10");
    			    inValue = Console.ReadLine();
    			}
    		}else{
    			Console.WriteLine("Invalid input = 0 stored in intValue");
    			inValue = Console.ReadLine();
    		}
    	}
    	sum += intValue;
    	scoreArray[counter] = intValue;
    	counter++;
    }
