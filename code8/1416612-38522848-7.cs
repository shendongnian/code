    class OnlyOneOption
    {
        // Constructor is private so users cannot create their own instances.
    	private OnlyOneOption() {} 
    	
    	public static OnlyOneOption OptionA = new OnlyOneOption();
    	public static OnlyOneOption OptionB = new OnlyOneOption();
    	public static OnlyOneOption OptionC = new OnlyOneOption();
    }
