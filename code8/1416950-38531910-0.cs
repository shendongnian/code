    cost = 50;
    if (power5.isOn)
    {
        if (cost + memorybar.value > 100)
        {
            error.text = "Exeeds maximum memory";
            power5.isOn = false;  
        }
        else
        {
            memorybar.value = memorybar.value + cost;
            
        }
    }
    else
    {
        memorybar.value = memorybar.value + cost;
    }
