        if(visible=false){
            DishButton.setVisibility(View.INVISIBLE); 
            SpoonButton.setVisibility(View.INVISIBLE); 
            cupButton.setVisibility(View.INVISIBLE); 
            FridgeButton.setVisibility(View.INVISIBLE);
        }
        else {
            DishButton.setVisibility(View.VISIBLE); 
            SpoonButton.setVisibility(View.VISIBLE); 
            cupButton.setVisibility(View.VISIBLE); 
            FridgeButton.setVisibility(View.VISIBLE); 
            visible=true;
        }
    }
