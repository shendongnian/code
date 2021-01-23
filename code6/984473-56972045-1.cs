    public partial class Form1 : Form
    {
        private Guid _guid1;
        private Guid _guid2;
        class MyClass
        {
            public readonly Guid Guid;
            public string Key;
            public string Value;
            public MyClass(Guid guid, string key, string value)
            {
                Key = key;
                Guid = guid;
                Value = value;
            }
            public override int GetHashCode()
            {
                return Guid.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj is MyClass)
                    return this.Guid.Equals(((MyClass) obj).Guid);
                return base.Equals(obj);
            }
        }
        public Form1()
        {
            InitializeComponent();
            olv.FullRowSelect = true;
            olv.HideSelection = false;
            _guid1 = Guid.Parse("026c90aa-7fb8-452d-b8bc-b42fd7bc0e7f");
            _guid2 = Guid.Parse("85ea0ce0-da65-412f-8198-724c196342da");
            
            olv.AddObjects(new []
            {
                //two objects that will be updated
                new MyClass(_guid1,"go","nuts"), 
                new MyClass(_guid2,"lol","rly?"),
                
                //one object that will disapear
                new MyClass(Guid.NewGuid(),"bye","bye")
            });
            
        }
        private void BtnRefreshObjects_Click(object sender, System.EventArgs e)
        {
            olv.BeginUpdate();
            
            //remember the old objects
            var oldSelection = olv.SelectedObjects.Cast<object>().ToList();
            
            //swap them for the new objects
            olv.ClearObjects();
            olv.AddObjects(
                new []
            {
                //This object stays the same
                new MyClass(_guid1,"go","nuts"), 
                //This object changes fields (but is still the same record due to Guid)
                new MyClass(_guid2,"omg2","omg3"),
                //This is a new object
                new MyClass(Guid.NewGuid(),"omg5","omg6")
            });
            
            //reset the old selection (even though they are stale objects the selection works because of Equality override)
            olv.SelectedObjects = oldSelection;
            olv.EndUpdate();
        }
    }
