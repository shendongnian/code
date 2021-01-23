    //In your class a private member:
    private int masterCounter = 1;
    //In your function  
    for(int i = (masterCounter >= 500 ? 1 : masterCounter); i <= 500 ; i++)
    {
        Debug.Print("Value of i: " + i.ToString());               
        if(i % 5 == 0)
        {
            masterCounter = i + 1;
            break;
        }                         
    }
