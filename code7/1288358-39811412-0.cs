    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ZedGraph;
    
    namespace WindowsFormsApplication1 {
    
        static class Program {
            /// <summary>
            /// Point d'entrée principal de l'application.
            /// </summary>
            [STAThread]
            static void Main() {
                Application.Run(new Form1());
            }
    
            class Form1 : Form {
                ZedGraphControl zgc;
    
                public Form1() {
                    this.WindowState = FormWindowState.Maximized;
                    zgc = new ZedGraphControl {
                        Parent = this,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(10)
                    };
    
                    var myPane = zgc.GraphPane;
                    myPane.Title.Text = "Test";
                    myPane.XAxis.Title.Text = "X Value";
                    myPane.YAxis.Title.Text = "Y Axis";
                    myPane.XAxis.Scale.MaxAuto = true;
    
                    var myCurve = myPane.AddCurve("Curve 1", samp, Color.Blue, SymbolType.Star);
                    myCurve.Symbol.Fill = new Fill(Color.White);
                    myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
                    myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
                }
    
                RollingPointPairList samp = new RollingPointPairList(105);
    
                protected override void OnLoad(EventArgs e) {
                    base.OnLoad(e);
    
                    var r = new Random();
                    var tim = new System.Timers.Timer { Interval = 10 };
                    tim.Elapsed += (s1, e1) => {
                        TimerEventProcessor(r.Next(-10, 10));
                    };
                    tim.Start();
                }
    
                int x1 = 0;
    
                void TimerEventProcessor(int d) {
                    x1++;
                    samp.Add(d, x1);
                    zgc.AxisChange();
                    zgc.Invalidate();
                }
            }
        }
    }
