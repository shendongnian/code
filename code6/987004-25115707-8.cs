    List<Posting> objList = new List<Posting>();
	Enumerable.Range(0,100)
	.Select
	(
		(x,i)=>new Posting
		{
			Key1 = i,
			GetPostingChoice = Enumerable.Range(0,5).Select((p,j)=>new Choice{ID = i,VAL = j}).ToList()
		}
	);
