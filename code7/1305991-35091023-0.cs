    public int Money;
    public IEnumerator IncreaseMoney(int amount, float interval) 
    {
         while(true)
         {
              Money += amount;
              yield return new WaitForSeconds(interval);   
         }
    }
    //somewhere within this class
    void Start() 
    {
       //Start increasing the money by 50 every 2 seconds
       StartCoroutine(IncreaseMoney(50, 2.0)); 
    }
