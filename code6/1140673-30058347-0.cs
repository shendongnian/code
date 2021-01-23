    public partial class Form1 : Form
    {
        StateWithColor[] colors = new StateWithColor[] {
            new StateWithColor(0, Color.Black),
            new StateWithColor(1, Color.White)
        };
        FlickTimer<Button> timer1Button, timer2Button;
        public Form1()
        {
            InitializeComponent();
            timer1Button = new FlickTimer<Button>(colors, 500, button1);
            timer2Button = new FlickTimer<Button>(colors, 100, button2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
    public struct StateWithColor
    {
        public int State;
        public Color Color;
        public StateWithColor(int state, Color color)
        {
            Color = color;
            State = state;
        }
    }
    public class FlickTimer<T> : IDisposable
        where T: Control
    {
        public T Target { get; set; }
        protected readonly IList<StateWithColor> possibleStates = new List<StateWithColor>();
        protected int currentState = 0;
        protected object lockState = new object();
        protected Timer timer = new Timer();
        protected void Flicker(object sender, EventArgs e)
        {
            if (Target == null)
            {
                return;
            }
            if (Target.InvokeRequired)
            {
                Target.Invoke(new EventHandler(Flicker), sender, e);
                return;
            }
            lock (lockState)
            {
                Target.BackColor = possibleStates[currentState].Color;
                currentState++;
                if (currentState >= possibleStates.Count)
                {
                    currentState = 0;
                }
            }
        }
        public FlickTimer(StateWithColor[] states, int timeout = 100, T target = null)
        {
            Target = target;
            lock (lockState)
            {
                foreach (var state in states)
                {
                    possibleStates.Add(state);
                }
            }
            timer.Interval = timeout;
            timer.Tick += Flicker;
            Start();
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Dispose()
        {
            if (timer != null)
            {
                Stop();
                timer.Tick -= Flicker;
                timer = null;
            }
        }
    }
