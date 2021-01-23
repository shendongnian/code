    internal class MainFormPresenter
    {
        private readonly SimpleContext _context = new SimpleContext();
        private readonly IMainFormView _mainFormView;
        private readonly IPeopleListView _peopleListView;
        private readonly IPersonInfoView _personInfoView;
        public MainFormPresenter(IMainFormView mainFormView)
        {
            _peopleListView = mainFormView.PeopleListView;
            _personInfoView = mainFormView.PersonInfoView;
            _mainFormView = mainFormView;
            _mainFormView.Load += MainFormViewOnLoad;
            _mainFormView.FormClosed += MainFormViewOnFormClosed;
            _peopleListView.SelectionChanged += OnSelectedNameChanged;
        }
        private void OnSelectedNameChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = _peopleListView.GetSelectedRow();
            Person person = (Person) row.DataBoundItem;
            
            _personInfoView.SetFirstName(person.FirstName);
            _personInfoView.SetLastName(person.LastName);
            _personInfoView.SetBirthDate(person.BirthDate);
        }
        private void MainFormViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            _context.Dispose();
        }
        private void MainFormViewOnLoad(object sender, EventArgs e)
        {
            _context.People.Load();
            BindingList<Person> people = _context.People.Local.ToBindingList();
            BindingSource bSource = new BindingSource
            {
                DataSource = people,
                RaiseListChangedEvents = true
            };
            _peopleListView.SetDataSource(bSource);
        }
    }
