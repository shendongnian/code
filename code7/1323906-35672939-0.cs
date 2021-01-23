    bool CheckTrsfSelectIsProcessing = false;
    private void CheckTrsfSelect(object sender, ItemCheckedEventArgs e)
    {
        if (!CheckTrsfSelectIsProcessing){
            CheckTrsfSelectIsProcessing = true;
            lvi = e.Item; 
            if (lvi.SubItems[2].Text == "HOTEL" && TrsfSelect == 1 &&lvi.Checked)
            {
                MessageBox.Show("Blabla.");
                lvi.Checked = false;
            }
            CheckTrsfSelectIsProcessing = false;
        }
    } 
