    public void M() {
        
        Test(5);
        Test(5m);
        
    }
    
    public void Test(decimal someValue)
	{
  		decimal whyyy = someValue * 5.5m;
        Console.WriteLine(whyyy);
	}
