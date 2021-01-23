    double result = 0;
    double sum = 0;
    
    foreach(var item in OgrencilerListBox.Items){
        
    	double parsedItem;
        string yourItem = item.ToString();
        bool parsed = Double.TryParse(yourItem,out parsedItem);
    
        if(parsed){
            sum+=parsedItem;
        }
        else{
           continue;
        }
    }
    result = sum/OgrencilerListBox.Items.Count;
