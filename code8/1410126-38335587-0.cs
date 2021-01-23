    private MyEntities _ctx;
    private BaseRepository<Patient> _patientsRepository;
    private List<Patient> _patients;
    [TestInitialize]
    public void Initialize() {
      string connStr = ConfigurationManager.ConnectionStrings["MyEntities"].ConnectionString;
      DbConnection connection = EntityConnectionFactory.CreateTransient(connStr);
      _ctx = new MyEntities(connection);
      _patientsRepository = new BaseRepository<Patient>(_ctx);
      _patients = GetPatients();
    }
