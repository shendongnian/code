    public partial class Cumle : UserControl
    {
        public event EventHandler ConditionChangedToTrue;
        
        protected virtual void OnConditionChangedToTrue(EventArgs e)
        {
            if (ConditionChangedToTrue != null)
                ConditionChangedToTrue(this, e != null ? e : EventArgs.Empty);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Some Code....
            if (true) // add your condition
            {
                cond = true;
                ConditionChangedToTrue(null);
            }
        }
    }
    public partial class Form1 : Form
    {
        private Cumle cumle = new Cumle();
        public Form1()
        {
           InitializeComponent();
           cumle.ConditionChangedToTrue+= Cumle_ConditionChangedToTrue;
        }
        private void Cumle_ConditionChangedToTrue(object sender, EventArgs e)
        {
            // add your event handling code here
            throw new NotImplementedException();
        }
    }
