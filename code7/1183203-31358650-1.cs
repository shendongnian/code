    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace SharpDock
    {
        public partial class SettingsWindow : Form
        {
            public Properties.Settings s = Properties.Settings.Default;
            public SettingsWindow()
            {
                InitializeComponent();
                LoadSettings();
            }
            private void LoadSettings()
            {
                app1.Text = s.app1;
                app2.Text = s.app2;
                app3.Text = s.app3;
                app4.Text = s.app4;
                app5.Text = s.app5;
                app6.Text = s.app6;
                ico1.Text = s.ico1;
                ico2.Text = s.ico2;
                ico3.Text = s.ico3;
                ico4.Text = s.ico4;
                ico5.Text = s.ico5;
                ico6.Text = s.ico6;
            }
            private void Accept_Click(object sender, EventArgs e)
            {
                s.Save();
                MessageBox.Show("SharpDock", "You must restart the program for the changes to take effect.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            private void aButton_Click(object sender, EventArgs e)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Executable Files (*.exe) | *.exe";
                    ofd.Title = "Which executable would you like to launch?";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (sender == abutton1)
                        {
                            app1.Text = ofd.FileName;
                            s.app1 = ofd.FileName;
                        }
                        else if (sender == abutton2)
                        {
                            app2.Text = ofd.FileName;
                            s.app2 = ofd.FileName;
                        }
                        else if (sender == abutton3)
                        {
                            app3.Text = ofd.FileName;
                            s.app3 = ofd.FileName;
                        }
                        else if (sender == abutton4)
                        {
                            app4.Text = ofd.FileName;
                            s.app4 = ofd.FileName;
                        }
                        else if (sender == abutton5)
                        {
                            app5.Text = ofd.FileName;
                            s.app5 = ofd.FileName;
                        }
                        else if (sender == abutton6)
                        {
                            app6.Text = ofd.FileName;
                            s.app6 = ofd.FileName;
                        }
                    }
                }
            }
        
            private void iButton_Click(object sender, EventArgs e)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files (*.png) | *.png";
                    ofd.Title = "Which icon would you like?";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (sender == ibutton1)
                        {
                            ico1.Text = ofd.FileName;
                            s.ico1 = ofd.FileName;
                        }
                        else if (sender == ibutton2)
                        {
                            ico2.Text = ofd.FileName;
                            s.ico2 = ofd.FileName;
                        }
                        else if (sender == ibutton3)
                        {
                            ico3.Text = ofd.FileName;
                            s.ico3 = ofd.FileName;
                        }
                        else if (sender == ibutton4)
                        {
                            ico4.Text = ofd.FileName;
                            s.ico4 = ofd.FileName;
                        }
                        else if (sender == ibutton5)
                        {
                            ico5.Text = ofd.FileName;
                            s.ico5 = ofd.FileName;
                        }
                        else if (sender == ibutton6)
                        {
                            ico6.Text = ofd.FileName;
                            s.ico6 = ofd.FileName;
                        }
                    }
                }
            }
        }
    }
