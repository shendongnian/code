        using System;
        using System.Runtime.InteropServices;
        using System.Drawing;
        using System.Drawing.Text;
        using System.Windows.Forms;
        
        
        namespace WindowsFormsApplication3
        {
        
            public partial class Form1 : Form
            {
        
                [DllImport("User32.dll")]
                static extern IntPtr GetDC(IntPtr hwnd);
        
                public Form1()
                {
                    InitializeComponent();
                    this.Opacity = 0;
                }
        
                Label[] _Labels = new Label[2];
                String[] _LabelsText = new string[2];
                Graphics g;
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
                }
        
        
                private void draw()
                {
                    using (Graphics g = Graphics.FromHdc(GetDC(IntPtr.Zero)))
                    {
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        Font theFont = new Font(FontFamily.GenericSansSerif, 100.0F, FontStyle.Bold);
        
        
                        for (int i = 0; i < _Labels.Length; i++)
                        {
                            myColor = _Labels[i].ForeColor;
                            myBrush = new SolidBrush(myColor);
                            g.TextRenderingHint = TextRenderingHint.AntiAlias;
                            g.DrawString(_LabelsText[i], _Labels[i].Font, myBrush, _Labels[i].Location);
                        }
        
                    }
                }
        
        
                int dynNumCount = 0;
                private void dynamicNumber_Tick(object sender, EventArgs e)
                {
                    dynNumCount++;
                    _LabelsText[1] = Convert.ToString(dynNumCount);
                    draw();
                }
            }
        }
