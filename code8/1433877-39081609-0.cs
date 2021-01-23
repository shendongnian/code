    public partial class Form1 : Form
    {
        private int tick = 0;
        public Form1()
        {
            InitializeComponent();
        }
        bool changed = false;        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (changed == true)
            {
                changed = false;
                this.Refresh();
            }
            else
            {
                if(tick<3)
                {
                    timer1.Enabled = true;
                    timer1.Start();  
                }                          
                changed = true;
                this.Refresh();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (changed)
            {              
                Graphics g1 = e.Graphics;
                int diff = 1;
                Rectangle rect2 = new Rectangle(comboBox1.Location.X - diff, comboBox1.Location.Y - diff, comboBox1.Width + diff, comboBox1.Height + diff);
                using (LinearGradientBrush br = new LinearGradientBrush(rect2,Color.Red,Color.Blue,LinearGradientMode.Horizontal))
                {
                    ColorBlend color_blend = new ColorBlend();
                    color_blend.Colors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Lime, Color.Blue, Color.Indigo, Color.DarkViolet};
                    color_blend.Positions = new float[] { 0 / 6f, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 6 / 6f };
                    br.InterpolationColors = color_blend;
                    Pen p = new Pen(br, 10);
                    e.Graphics.DrawRectangle(p, rect2);
                }                
            }
            else
            {
                Pen p = new Pen(Color.Transparent);
                Graphics g = e.Graphics;
                int diff = 1;
                g.DrawRectangle(p, new Rectangle(comboBox1.Location.X - diff, comboBox1.Location.Y - diff, comboBox1.Width + diff, comboBox1.Height + diff));
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(tick<3)
            {
                comboBox1_SelectedIndexChanged(null, null);
                tick++;
            }
            else
            {
                timer1.Stop();
                tick = 0;
            }
                       
        }     
    }
