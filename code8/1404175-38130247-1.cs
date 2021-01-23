    [System.NonSerialized] public string pin = "";
    
	public void UserClickedButtonNumbered(int digitNumber)
		{
		Debug.Log("that button name is " +digitNumber);
        pin = pin + digitNumber.ToString();
        pin = FourOnly(pin);
        Debug.Log("So far, the user entered: " +pin);
        if ( pin == "1313" ) Debug.Log("code unlocked!");
		}
