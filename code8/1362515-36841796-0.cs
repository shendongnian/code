    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                AlertForm af = new AlertForm();
                af.Show();
    
                //I assume CallTreeView is not implemented in your form's code behind,
                //if it is you do not need to pass it as a parameter
                await Task.Run(async () => await CallTreeView(treeView1, af.Cts.Token));
    
                af.Close();
            }
    
            private async Task CallTreeView(TreeView tv, CancellationToken token)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        //clean up whatever you need to
                        return;
                    }
                    else
                    {
                        await Task.Delay(500); //just simulate doing something
                        //add nodes...
                    }
                }
            }
        }
    }
