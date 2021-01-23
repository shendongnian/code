	private IMapper map;
	
    private void InitMapper()
    {
        map = new MapperConfiguration(cfg => {
            cfg.CreateMap<ORM.SampleSentence, SampleSentence>();
            cfg.CreateMap<ORM.WordForm, WordForm>();
            cfg.CreateMap<ORM.Word, Word>();
            cfg.CreateMap<SampleSentence, ORM.SampleSentence>();
            cfg.CreateMap<WordForm, ORM.WordForm>();
            cfg.CreateMap<Word, ORM.Word>();
            cfg.AddProfile<CollectionProfile>();
        }).CreateMapper();
        EquivilentExpressions.GenerateEquality.Add(new GenerateEntityFrameworkPrimaryKeyEquivilentExpressions<YourDbContext>(map));
    }
	public async Task<IHttpActionResult> Put([FromBody]Word word)
	{
		var dbWord = db.Word.Include(w => w.WordForm).Where(w => w.WordId == word.WordId).First();
		if (dbWord != null)
		{
			InitMapper();
			map.Map(word, dbWord);
			db.SaveChanges();
			var ret = map.Map<Word>(dbWord);
			return Ok(ret);
		}
		else
		{
			return NotFound();
		}
	
	}
