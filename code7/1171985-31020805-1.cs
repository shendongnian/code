    int found = 0;
    int positionX = 0;
    int positionY = 0;
    for(int a = 0; a < list.Count && a >= 0; a++){
        if(list[a] == x && !found){
            positionX = a;
            found = 1;
            continue;
        }
        if(found){
            if(list[a] == y){
                positionY = a;
                break;
            }
            x -= 2; //from the moment x is found, go back one step at the time (search backwards)
        }
    }
        
