    public Interface IConverter
    { 
    	IScoreConverter ScoreConverter { get; set; };//use constructorinjection instead
    	void ModifyScore(string convertTo);
    }
    
    public Interface IScoreConverter
    { 
    	DetermineScore();
    }
