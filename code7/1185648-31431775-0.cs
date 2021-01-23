    Dictionary<int, string> quiz =
    	    new Dictionary<int, string>()
    {
    	{ 10, "Result1" },
    	{ 20, "Result2" },
    	{ 30, "Result3" },
    	{ 40, "Result4" },
    	{ 50, "Result5" },
    	{ 60, "Result6" }
    };
    
    void Update (int score) {
    	Application.LoadLevel(quiz[score]);
    }
