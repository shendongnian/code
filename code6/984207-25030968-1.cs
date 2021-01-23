    class RunScript : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int scriptCounter;
        public async void RunScriptList()
        {
            ScriptCounter = 0;
            foreach (var cell in Enumerable.Range(1, 15))
            {
                ScriptCounter++;
                await Task.Delay(1000);
                //DoSomething
            }
        }
        public int ScriptCounter
        {
            get { return scriptCounter; }
            set
            {
                scriptCounter = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    private RunScript rs = new RunScript();
    public Form1()
    {
        InitializeComponent();
        var binding = new Binding("SelectedIndex", rs, "ScriptCounter", false, DataSourceUpdateMode.OnPropertyChanged);
        listBox1.DataBindings.Add(binding);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        rs.RunScriptList();
    }
