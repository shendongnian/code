    public class UnitOfWorkMockBuilder : IBuilder
    {
    	#region <Constructors>
    
    	public UnitOfWorkMockBuilder(bool autoSeed)
    	{
    		ClaimsRepositoryBuilder = new ClaimsRepositoryMockBuilder(autoSeed);
    		SomeOtherRepositoryBuilder = new SomeOtherRepositoryMockBuilder(autoSeed);
    	}
    
    	#endregion
    
    	#region <Properties>
    
    	public ClaimsRepositoryMockBuilder ClaimsRepositoryBuilder { get; set; }
    	
    	public SomeOtherRepositoryMockBuilder SomeOtherRepositoryBuilder { get; set; }
    	
    	#endregion
    
    	#region <Methods>
    
    	public Mock<IMyUnitOfWork> CreateMock()
    	{
    		var unitOfWork = new Mock<IMyUnitOfWork>();
    
    		var depClaimTransactionsRepository = ClaimTransactionsRepositoryBuilder.CreateMock();
    		var depSomeOtherRepository = SomeOtherRepository.CreateMock();
    
    		unitOfWork.SetupAllProperties();
    		unitOfWork.Object.Claim = depClaimsRepositoryBuilder.Object;
    		unitOfWork.Object.SomeOther = depSomeOtherRepository.Object;
    
    		return unitOfWork;
    	}
    
    	#endregion
    }
