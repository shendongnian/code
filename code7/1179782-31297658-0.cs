     public MahAppsService(ICommandManager commandManager, IMessageService messageService, IUIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvicer)
        {
            Argument.IsNotNull(() => commandManager);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => authenticationProvicer);
            _commandManager = commandManager;
            _messageService = messageService;
            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvicer;
        }
