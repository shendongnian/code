    private void textBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    textBox1.ContextMenu = new ContextMenu();
                }
            }
