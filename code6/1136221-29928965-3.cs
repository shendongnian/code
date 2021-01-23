    private void btnEdit_Click(object sender, EventArgs e)
    {
       EditWordForm myEditWordForm = new EditWordForm();
       myEditForm.SelectedValue = lstDictionary.GetItemText(lstDictionary.SelectedItem);
    
       myEditWordForm.ShowDialog();
    
       this.dictionaryTableAdapter.Fill(this.dictionaryDataSet.Dictionary);
    
    }
