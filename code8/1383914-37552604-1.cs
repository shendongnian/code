    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
    
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            Label[] _Labels = new Label[2];
            String[] _LabelsText = new string[2];
            Graphics g;
            Bitmap btm;
            Color myColor;
            SolidBrush myBrush;
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _Labels[0] = label1;
                _Labels[1] = label2;
    
                _LabelsText[0] = "CPU";
                _LabelsText[1] = "0";
    
                label1.Text = "";
                label2.Text = "";
                draw();
                this.BackgroundImage = btm;
    
            }
    
            public void draw()
            {
                btm = new Bitmap(this.Width, this.Height);
                g = Graphics.FromImage(btm);
                for (int i = 0; i < _Labels.Length; i++)
                {
                    myColor = _Labels[i].ForeColor;
                    myBrush = new SolidBrush(myColor);
    
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.DrawString(_LabelsText[i], _Labels[i].Font, myBrush, _Labels[i].Location);
                }
            }
    
    
            int dynNumCount = 0;
            private void dynamicNumber_Tick(object sender, EventArgs e)
            {
                dynNumCount++;
                _LabelsText[1] = Convert.ToString(dynNumCount);
                draw();
                this.BackgroundImage = btm;
    
            }
        }
    }
