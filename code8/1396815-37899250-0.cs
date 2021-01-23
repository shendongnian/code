    public delegate void LightChangedHandler(object sender, Lights light);
    public enum Lights
    {
        Green,
        Orange,
        Red
    }
    public partial class TrafficLights : UserControl
    {
        public event LightChangedHandler LightChanged;
        protected virtual void OnChanged(Lights light) 
        {
            if (LightChanged != null)
            {
                LightChanged(this, light);
            }
        }
        private bool _changing = false;
        public TrafficLights()
        {
            InitializeComponent();
        }
        public void SetLight(Lights light)
        {
            if (_changing)
            {
                return;
            }
            _changing = true;
            switch (light)
            {
                case Lights.Green:
                    radioGreen.Checked = true;
                    radioOrange.Checked = false;
                    radioRed.Checked = false;
                    break;
                case Lights.Orange:
                    radioOrange.Checked = true;
                    radioGreen.Checked = false;
                    radioRed.Checked = false;
                    break;
                case Lights.Red:
                    radioRed.Checked = true;
                    radioGreen.Checked = false;
                    radioOrange.Checked = false;
                    break;
            }
            OnChanged(light);
            _changing = false;
        }
        private void radioGreen_CheckedChanged(object sender, EventArgs e)
        {
            SetLight(Lights.Green);
        }
        private void radioOrange_CheckedChanged(object sender, EventArgs e)
        {
            SetLight(Lights.Orange);
        }
        private void radioRed_CheckedChanged(object sender, EventArgs e)
        {
            SetLight(Lights.Red);
        }
    }
