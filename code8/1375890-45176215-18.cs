        public partial class Builder
        {
        	#region <Methods>
        
        	public T CreateInstance<T>(IDemoDbUnitOfWork unitOfWork, bool byFullName = false)
        	{
        		if (unitOfWork == null)
        			throw new ArgumentNullException("UnitOfWork");
        
        		// Here, I am passing-in a MOCK of the UnitOfWork & "shimming" it into "T" via IoC
        		var container = IoC.Initialize();
        		container.Inject(typeof(IDemoDbUnitOfWork), unitOfWork);
        
        		return container.GetInstance<T>();
        	}
        
            public Mock<IDemoDbUnitOfWork> CreateMockUnitOfWork()
            {
                var unitOfWork = new Mock<IDemoDbUnitOfWork>();
    
                // DBO Tables
                var bankAccountRepository = BankAccountRepositoryBuilder.CreateMock();
                var bankAccountTypeRepository = BankAccountTypeRepositoryBuilder.CreateMock();
    
                unitOfWork.SetupAllProperties();
    
                // DBO Tables
                unitOfWork.SetupGet(x => x.BankAccounts).Returns(bankAccountRepository.Object);
                unitOfWork.SetupGet(x => x.BankAccountTypes).Returns(bankAccountTypeRepository.Object);
    
                return unitOfWork;
            }
    
        	#endregion
        }
    
