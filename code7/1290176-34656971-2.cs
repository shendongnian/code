    private void DataGridViewA_RowLeave(object sender, DataGridViewCellEventArgs e)
        {            
            if (IsSaveNeeded)
            {
                if (dataGridViewA.Focused == false)
                {   //DataGridViewA without focus, then nothing to do
                    return;
                }
    
                if (!WasSavedPerUserRequest())
                {
                    var recordstate = AlternateDGV.CurrentRow.Cells[Glossary.RecordStateName].Value.ToString();
                    if (recordstate == Glossary.AddedRecordState)   // if it was a new row added and the user doesn't want to save
                    {                        
                        AlternateDGV.CurrentRow.Delete();
                    }
                    else if (recordstate == Glossary.EditedRecordState) // if it was a row from DB and the user doesn't want to save, refresh with saved data
                    {
                        AlternateDGV.CurrentRow.Refresh(_items);
                    }
                }
            }
        }
