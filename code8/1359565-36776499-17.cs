    public class ClaimRepositoryMockBuilder : IRepositoryMockBuilder<Claim>
    {
    	#region <Constructor>
    
    	public ClaimRepositoryMockBuilder(bool autoSeed)
    	{
    		Entities = AutoSeed(autoSeed);
    		EntityState = EntityState.Unchanged;
    	}
    
    	#endregion
    
    	#region <Properties>
    
    	public List<Claim> Entities { get; private set; }
    
    	public EntityState EntityState { get; private set; }
    
    	#endregion
    
    	#region <Methods>
    
    	public Mock<IRepository<Claim>> CreateMock()
    	{
    		var repository = new Mock<IRepository<Claim>>();
    
    		repository.SetupAllProperties();
    		repository.Setup(x => x.GetActive()).Returns(this.Entities.AsQueryable());
    		repository.Setup(x => x.GetAll()).Returns(this.Entities.AsQueryable());
    		repository.Setup(x => x.GetById(It.IsAny<object>())).Returns((object id) => { return this.Entities.Where(e => e.ClaimId == id.ToString()).FirstOrDefault(); });
    		repository.Setup(x => x.Find(new object[] { It.IsAny<string>() })).Returns((object id) => { return this.Entities.Where(e => e.ClaimId == id.ToString()).FirstOrDefault(); });
    		repository.Setup(x => x.Add(It.IsAny<Claim>())).Callback<Claim>(x => { this.Entities.Add(x); }).Verifiable();
    		repository.Setup(x => x.AddRange(It.IsAny<IEnumerable<Claim>>())).Callback<IEnumerable<Claim>>(x => { this.Entities.AddRange(x); }).Verifiable();
    		repository.Setup(x => x.Update(It.IsAny<Claim>())).Callback<Claim>(x => { UpdateEntity(x); }).Verifiable();
    		repository.Setup(x => x.Delete(It.IsAny<Claim>())).Callback<Claim>(x => { DeleteByEntity(x); }).Verifiable();
    		repository.Setup(x => x.Delete(It.IsAny<object>())).Callback<object>(x => { DeleteById(x); }).Verifiable();
    		repository.Setup(x => x.ApplyState(It.IsAny<Claim>(), It.IsAny<EntityState>())).Callback<Claim, EntityState>((x, y) => { this.EntityState = y; }).Verifiable();
    		repository.Setup(x => x.GetState(It.IsAny<Claim>())).Returns((Claim claim) => { return this.EntityState; });
    
    		return repository;
    	}
    		   
    	#region private
    	
    	private void DeleteById(object id)
    	{
    		var entity = this.Entities.FirstOrDefault(x => x.ClaimId == id.ToString());
    		if (entity != null)
    			this.Entities.RemoveAt(Entities.IndexOf(entity));
    	}
    
    	private void DeleteByEntity(Claim deletedEntity)
    	{
    		var entity = this.Entities.FirstOrDefault(x => x.ClaimId == deletedEntity.ClaimId);
    		if (entity != null)
    			this.Entities.Remove(entity);
    	}
    
    	private void UpdateEntity(Claim updatedEntity)
    	{
    		var entity = this.Entities.FirstOrDefault(x => x.ClaimId == updatedEntity.ClaimId);
    		if (entity != null)
    			entity = updatedEntity;
    
    	}
    
    	private List<Claim> AutoSeed(bool autoSeed)
    	{
    		if (!autoSeed)
    			return new List<Claim>();
    
    		var database = new List<Claim>();
    		database.Add(new Claim() 
    		{
    			// Set Properties Here
    		});
    		database.Add(new Claim()
    		{
    			// Set Properties Here
    		});
    		database.Add(new Claim()
    		{
    			// Set Properties Here
    		});
    
    		return database;
    	}
    
    	#endregion
    
    	#endregion
    }
