        private void ButtonClickHandler(object sender, EventArgs e)
        {
            Console.WriteLine("kkk");
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = @"c:\";
                dlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("open ok");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Dialog open error occurred: " + ex.Message);
            }
        }
