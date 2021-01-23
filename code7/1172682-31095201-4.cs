            //Test for the customized "Save As" dialog
            private void button1_Click(object sender, EventArgs e)
            {
                //Arbitrary User Control
                myUserControl ctrl = new myUserControl();
    
                using (CustomSaveFileDialog csfdg = new CustomSaveFileDialog(ctrl))
                {
                    csfdg.Dlg.FileName = "test";
    
                    //Show the Save As dialog associated to the CustomFileDialog control
                    DialogResult res = csfdg.Dlg.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.OK)
                        MessageBox.Show("Save Dialog Finished");
                }
            }
