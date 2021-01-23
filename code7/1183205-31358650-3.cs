    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace SharpDock
    {
        public partial class SettingsWindow : Form
        {
            public SettingsWindow()
            {
                InitializeComponent();
                LoadSettings();
            }
            private void LoadSettings()
            {
                app1.Text = Properties.Settings.Default.app1;
                app2.Text = Properties.Settings.Default.app2;
                app3.Text = Properties.Settings.Default.app3;
                app4.Text = Properties.Settings.Default.app4;
                app5.Text = Properties.Settings.Default.app5;
                app6.Text = Properties.Settings.Default.app6;
                ico1.Text = Properties.Settings.Default.ico1;
                ico2.Text = Properties.Settings.Default.ico2;
                ico3.Text = Properties.Settings.Default.ico3;
                ico4.Text = Properties.Settings.Default.ico4;
                ico5.Text = Properties.Settings.Default.ico5;
                ico6.Text = Properties.Settings.Default.ico6;
            }
            private void Accept_Click(object sender, EventArgs e)
            {
                Properties.Settings.Default.Save();
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
                            Properties.Settings.Default.app1 = ofd.FileName;
                        }
                        else if (sender == abutton2)
                        {
                            app2.Text = ofd.FileName;
                            Properties.Settings.Default.app2 = ofd.FileName;
                        }
                        else if (sender == abutton3)
                        {
                            app3.Text = ofd.FileName;
                            Properties.Settings.Default.app3 = ofd.FileName;
                        }
                        else if (sender == abutton4)
                        {
                            app4.Text = ofd.FileName;
                            Properties.Settings.Default.app4 = ofd.FileName;
                        }
                        else if (sender == abutton5)
                        {
                            app5.Text = ofd.FileName;
                            Properties.Settings.Default.app5 = ofd.FileName;
                        }
                        else if (sender == abutton6)
                        {
                            app6.Text = ofd.FileName;
                            Properties.Settings.Default.app6 = ofd.FileName;
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
                            Properties.Settings.Default.ico1 = ofd.FileName;
                        }
                        else if (sender == ibutton2)
                        {
                            ico2.Text = ofd.FileName;
                            Properties.Settings.Default.ico2 = ofd.FileName;
                        }
                        else if (sender == ibutton3)
                        {
                            ico3.Text = ofd.FileName;
                            Properties.Settings.Default.ico3 = ofd.FileName;
                        }
                        else if (sender == ibutton4)
                        {
                            ico4.Text = ofd.FileName;
                            Properties.Settings.Default.ico4 = ofd.FileName;
                        }
                        else if (sender == ibutton5)
                        {
                            ico5.Text = ofd.FileName;
                            Properties.Settings.Default.ico5 = ofd.FileName;
                        }
                        else if (sender == ibutton6)
                        {
                            ico6.Text = ofd.FileName;
                            Properties.Settings.Default.ico6 = ofd.FileName;
                        }
                    }
                }
            }
        }
    }
