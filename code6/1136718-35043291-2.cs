    public partial class Form1 : Form
    {
        private static Timer timer;
        private static bool[] keys_down;
        private static Keys[] key_props;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            keys_down = new bool[4];
            key_props = new []{Keys.A, Keys.D, Keys.W, Keys.S};
            timer = new Timer();
            timer.Interval = 15; // Roughly 67 FPS
            timer.Tick += tick;
            timer.Start();
            KeyDown += key_down_event;
            KeyUp += key_up_event;
            ... // More things to do when the form loads.
        }
        
        private void tick(Object source, EventArgs e)
        {
            ... // Do this every timing interval.
            byte n = 0;
            foreach (var v in keys_down)
            {
                if (n == 3 && v)
                    ... // If the "s" key is being held down, no key delay issues. :)
                n++;
            }
            ...
        }
        
        private void key_down_event(object sender, KeyEventArgs e)
        {
            byte n = 0;
            foreach (var v in keys_down)
            {
                if (e.KeyCode == key_props[n])
                    keys_down[n] = true;
                n++;
            }
        }
        
        private void key_up_event(object sender, KeyEventArgs e)
        {
            byte n = 0;
            foreach (var v in keys_down)
            {
                if (e.KeyCode == key_props[n])
                    keys_down[n] = false;
                n++;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }
    }
