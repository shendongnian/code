        using System;
        using System.Windows.Forms;
        using System.Windows.Input;
        
                namespace ViewTest
                {
                    public partial class ViewTest : Form
                    {
                        private void ViewTest_KeyDown(object sender, KeyEventArgs e)
                        {
                            if (Keyboard.IsKeyDown(System.Windows.Input.Key.W) && 
                                Keyboard.IsKeyDown(System.Windows.Input.Key.D))
                            {
                                // do something
                            }
                        }
                }
