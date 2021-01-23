    public partial class Results : Form // (0)
    {
        public int  time1, time2, time3;
        FormLevel1 rez1 = new FormLevel1(); //(1)
        ...
    
        public Results()
        {
            InitializeComponent(); 
            Calculations(); // (2) Assuming you call Calculations() here
        }
    
        void Calculations()
        {
            time1 = rez1.levelTime;
            MessageBox.Show(time1.ToString()); //(3)
            ...
        }
    }
