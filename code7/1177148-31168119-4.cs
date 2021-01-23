    try
        {
            DataTable newDT = dt.GetChanges();
            if(newDT != null)
            {
                sda.Update(newDT);
            }
            MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
