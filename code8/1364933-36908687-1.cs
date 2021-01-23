    switch (MessageBox.Show("Etes vous sûre de vouloir fermer le programme ?", "Your_Application_Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    //Action if No
                    break;
               
            }
