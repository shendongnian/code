        private Mock<IConnector> _arc;
        private Mock<IMainForm> _arForm;
        private MainController _controller;
        private Dictionary<string, string> _fields;
            
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _fields = new Dictionary<string, string>();
            _arc = new Mock<IConnector>();
            _arForm = new Mock<IMainForm>();
            //The magic line:
            _arForm.SetupGet(x => x.Fields).Returns(_fields);
            _controller = new MainController(_arc.Object)
            {
                View = _arForm.Object
            };
        }
