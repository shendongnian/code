	private Repository _sut;
	private IEntityService _serviceFake;
	private ICustomerContext _contextFake;
	[SetUp]
	public void SetUp()
	{
		_serviceFake = MockRepository.GenerateMock<IEntityService>();
		_sut = new Repository(_serviceFake);
		_contextFake = MockRepository.GenerateMock<ICustomerContext>();
		_serviceFake.Stub(x => x.GetCustomerContext()).Return(_contextFake);
	}
	
