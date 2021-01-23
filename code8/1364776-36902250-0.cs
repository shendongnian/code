        public partial class Form1 : Form, INotifyPropertyChanged
        {
    
            int x = 50;
            public int X
            {
                get { return x; }
                set { x = value; OnPropertyChanged("X"); }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                label1.DataBindings.Add("Text", this, "X", true, DataSourceUpdateMode.OnPropertyChanged);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                X++;
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
    }
