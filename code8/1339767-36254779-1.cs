    //Model
    class Person : INotifyPropertyChanged
    {
        //Properties with notification
    }
    //Views
    abstract class View
    {
        //Base class for all views
        public abstract void SetDataSource(object source);
        protected virtual void Refresh();
        public abstract void Show();
    }
    //Data grid view
    class DataGridView : View
    {
        private Controller _controller = null;
        private System.Windows.Forms.DataGrid _grid = new System.Windows.Forms.DataGrid();
        public DataGridView(Controller controller)
        {
            _controller = controller;
        }
        public override void SetDataSource(object dataSource)
        {
            _grid.DataSource = dataSource;
        }
        public override void Show()
        {
        }
        protected override void Refresh
        {
            _grid.Refresh();
        }
    }
    //Controllers
    abstract class Controller
    {
        //Base controller
        public abstract void Init();
        public abstract void Show();
        public abstract void ViewChanged(object args);
    }
    //Person presenter
    class PersonGridController : Controller
    {
        private DataGridView _view = new DataGridView(this);
        private BindingList<Person> _persons = new BindingList<Person>();
        public override void Init()
        {
            //Initialize persons
            //Optional, auto update persons using thread/timer
        }
        public override void Show()
        {
            _view.SetDataSource(_persons);
            _view.Show();
        }
        public override void ViewChanged(object args)
        {
            //Based on arguments, perform filter, edit, save, etc.
        }
    }
