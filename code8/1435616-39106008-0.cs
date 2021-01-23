    private EmployeeTrainingRecordViewComponent(ITrainingRecordService TrainingRecordService, ITrainingLevelService TrainingLevelService, IOpNoService OpNoService, IMachineService MachineService, IEmployeeService EmployeeService)
    {
        _TrainingRecordService = TrainingRecordService;
        _TrainingLevelService = TrainingLevelService;
        _OpNoService = OpNoService;
        _MachineService = MachineService;
        _EmployeeService = EmployeeService;
    }
