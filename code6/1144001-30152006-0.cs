            try
            {
                if ((string)cmbCurse.SelectedItem == "Traseu") { popTraseu(); }
                else if ((string)cmbCurse.SelectedItem == "Bilete") { popBilete(); }
            }
             catch (Exception er) { MessageBox.Show(er.Message); }
