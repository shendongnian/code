    public interface IThirdPartyLibraryWrapper
    {
    	UserContext Current { get; }
    	UserContact CurrentContact { get; }
    	string UserContactName { get; }
    }
    
    public class ThirdPartyLibraryWrapper 
    	: IThirdPartyLibraryWrapper
    {
    	public UserContext Current 
    	{ 
    		get { /* return Current from third party library */}
    	}
    	
    	public UserContact CurrentContact 
    	{ 
    		get{ /* return CurrentContact from third party library */} 
    	}
    	
        public string UserContactName 
    	{ 
    		get{ /* return UserContactName from third party library */} 
    	}
    }
    
    public class ClassUnderTest
    {
    	// Inject 3rd party lib
    	private IThirdPartyLibraryWrapper _library;
    	public virtual IThirdPartyLibraryWrapper Library
    	{
    		get
    		{
    			if (_library == null)
    				_library = new ThirdPartyLibraryWrapper();
    			return _library;
    		}
            set
		    {
			    if (value != null)
				    _library = value;
		    }
    	}
    	
    	void DoSomething(){
    		UserContext Current = Library.Current; 
    	}
    }
    
    [TestMethod]
    public void DoSomething_WhenCalled_UsesLibraryMock()
    {
    	// Arrange
    	UserContext fakeUserContext = new UserContext();
    	Mock<IThirdPartyLibraryWrapper> libraryMock = new Mock<IThirdPartyLibraryWrapper>();
    	libraryMock.Setup(l => l.Current).Returns(fakeUserContext);
    	ClassUnderTest cut = new ClassUnderTest();
    	cut.Library = libraryMock.Object;
    	
    	// Act
    	cut.DoSomething()
    	
    	// Assert
    	// ...
    }
