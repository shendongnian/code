    public UserViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService, IPleaseWaitService pleaseWaitService)
    {
    	Argument.IsNotNull(() => uiVisualizerService);
    	Argument.IsNotNull(() => messageService);
    	Argument.IsNotNull(() => pleaseWaitService);
    
    	_uiVisualizerService = uiVisualizerService;
    	_messageService = messageService;
    	_pleaseWaitService = pleaseWaitService;
    
    	if (CatelEnvironment.IsInDesignMode)
    	{
    		return;
    	}
    
    	context = new olympEntities();
    	Users = new ObservableCollection<User>(context.Users.OrderByDescending(u => u.ID_User));
    
    	AddUser = new TaskCommand(OnAddUserExecuteAsync);
    	EditUser = new TaskCommand(OnEditUserExecuteAsync);
    	RemoveUser = new TaskCommand(OnRemoveUserExecuteAsync);
    
    	AddTicket = new TaskCommand(OnAddTicketExecuteAsync);
    	EditTicket = new TaskCommand(OnEditTicketExecuteAsync, OnEditTicketCanExecute);
    	RemoveTicket = new TaskCommand(OnRemoveTicketExecuteAsync, OnEditTicketCanExecute);
    }
