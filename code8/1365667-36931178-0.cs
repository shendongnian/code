    string matchStr = "abcde";
    
	[Route("Get")]
    public List<WordModel> Get()
    {      
        return db.Words.Where(p=>matchStr.ToUpper().Contains(p.UniqueID.ToUpper().FirstOrDefault())).Select(p=>new WordModel(){
		WordId  = p.WordId,
		CategoryId  = p.CategoryId 
		}).ToList();
    }
