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
    
    namespace POC_DoEvents_alternate
    {
        public partial class Form1 : Form
        {
            private Button button1;
            private Button button2;
            private TextBox textbox1;
    
            public Form1()
            {
                InitializeComponent();
    
                // programmatically create the controls so that the
                // entire source code is contained in this file.
                // normally you wouldn't do this.
    
                button1 = new Button();
                button1.Name = "button1";
                button1.Enabled = true;
                button1.Location = new Point(12, 12);
                button1.Size = new Size(144, 35);
                button1.Text = "button1";
                button1.Click += button1_Click;
                this.Controls.Add(button1);
    
                button2 = new Button();
                button2.Name = "button2";
                button2.Enabled = false;
                button2.Location = new Point(12, 53);
                button2.Size = new Size(144, 35);
                button2.Text = "button2";
                button2.Click += button2_Click;
                this.Controls.Add(button2);
    
                textbox1 = new TextBox();
                textbox1.Name = "textbox1";
                textbox1.Location = new Point(12, 94);
                textbox1.ReadOnly = true;
                textbox1.Size = new Size(258, 22);
                this.Controls.Add(textbox1);
    
                this.Load += new System.EventHandler(this.Form1_Load);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                textbox1.Text = "You can't press button 2 yet...";
                button1.Enabled = true;
                button2.Enabled = false;
                this.Cursor = Cursors.AppStarting;
    
                // start the long running task in a separate background thread
                ThreadPool.QueueUserWorkItem(Async_LongRunningTask, "Form1_Load");
    
                // calling the QueueUserWorkItem will not block. Execution will
                // contiune immediately with the lines below it.
    
                textbox1.BackColor = Color.LightPink;
    
                // this event handler finishes quickly so the form will paint and
                // be responsive to the user.
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textbox1.Text = "Button 1 pressed";
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                textbox1.Text = "Button 2 pressed";
            }
    
            private void Async_LongRunningTask(object state)
            {
                // put all your long running code here, just don't put any
                // UI work on this thread
    
                Thread.Sleep(5000);     // simulates a long running task
    
                // put any UI control work back on the UI thread
                this.Invoke((MethodInvoker)delegate
                {
                    button2.Enabled = true;
                    textbox1.Text = "End of long running task: " + state.ToString();
                    textbox1.BackColor = SystemColors.Control;
                    this.Cursor = Cursors.Default;
    
                    // as with anything on the UI thread, this delegate
                    // should end quickly
                });
    
                // once the delegate is submitted to the UI thread
                // this thread can still do more work, but being a
                // background thread, it will stop when the application
                // stops.
    
                Thread.Sleep(2000);     // simulates a long running task
            }
        }
    }
