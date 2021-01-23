    public partial class Form1 : Form
    {
        public delegate void Lights(bool state);
        public Lights setLights;
        public Form1()
        {
            InitializeComponent();
            setLights = new Lights(setLightsDelegate);
        }
        
        public void setLightsDelegate(bool state)
        {
            Input1GreenLight.Visible = state;
        }
    }
