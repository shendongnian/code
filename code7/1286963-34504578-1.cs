    Type myType = item.GetType();
    foreach (FieldInfo info in myType.GetFields())
        {
            string infoName = info.Name; //gets the name of the property
            Console.WriteLine(" Field Name = " + infoName +"and value = "+ info.GetValue(null));  
    		
        }
    	
    
