    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            private static CancellationTokenSource cts = new CancellationTokenSource();
            private CancellationToken ct = cts.Token;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Task.Factory.StartNew(() => 
                {
                    work_for_task(ct);
                }, this.ct);
            }
    
    
            private void work_for_task(CancellationToken ct)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                        break;
                    }
                    if (richTextBox2.InvokeRequired)
                    {
                        richTextBox2.Invoke((MethodInvoker)delegate
                        {
                            richTextBox2.AppendText("I AM IN: " + Thread.CurrentThread.Name + "\n");
                        });
    
                        Thread.Sleep(1400);
                    }
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("CANCELED");
                cts.Cancel();
            }
        }
    }
