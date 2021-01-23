    //In your class a private member:
    private int masterCounter = 0;
    //In your function  
    for(int i = (masterCounter >= 500 ? 0 : masterCounter); i <= 500 ; i++)
    {
        Debug.Print("Value of i: " + i.ToString());               
        if(i % 5 == 0)
        {
            masterCounter = i;
            break;
        }                         
    }
