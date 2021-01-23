    [ImplementPropertyChanged]
	public class CustomerViewModel : ViewModelBase<Customer>
	{
		public bool IsBusy { get; private set; }
		private ICustomerRepository _customerRepository;
		private IWindowService _windowService;
		
		[Inject]
		public CustomerViewModel(ICustomerRepository customerRepository, IWindowService windowService)
		{
			_customerRepository = customerRepository;
			_windowService = windowService;
			LoadData();
		}
		private async void LoadData()
		{
			IsBusy = true;
			
			try 
			{
				// Customer would be in your base, as public T BusinessObject { get; protected set; }
				BusinessObject = await _customerRepository.GetSelectedCustomer();
			}
			catch (Exception err)
			{
				_windowService.ShowErrorWindow(err);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
