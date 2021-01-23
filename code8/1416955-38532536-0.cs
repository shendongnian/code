    OnTriggerEnter(Collider other) {
        if (other.Tag == "powerTrigger") {
           updatePower = true;
        }
    }
    Update(){
        if(updatePower){
            if (power5.isOn){
                if (cost + memorybar.value > 100){
                    error.text = "Exeeds maximum memory";
                    power5.isOn = false;
                } else{
                    memorybar.value = memorybar.value + cost;
                }
            } else{
                memorybar.value = memorybar.value - cost;
                if(memorybar.cost <= 0){
                    memomrybar.cost = 0;
                    updatePower = false;
                }
            }
        }
    }
