    int StopIndex;
    double hgt = 0.0;
    for(int i = 0; i< tripList.Count; i++){
    
    controlToPrint.AddRow(tripList[i]);
    hgt += controlToPrintf.Items[i].Height; //You didn't mentioned what control you are using, so I guess it's a ListView
    if(hgt > controlToPrintf.Height) {
    controlToPrint.RemoveRow(tripList[i]); //Remove last ítem that caused rows exced the control's height
    StopIndex = --i; //Store the index of the item the control didn't allowed more rows to be added.
    break;
    }
    
    }
