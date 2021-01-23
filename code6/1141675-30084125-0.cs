    void checkData()
    {
        SuspendLayout();
        try
        {
            updateData();
        }
        catch (Exception ex)
        {
            MySqlException sqlEx = ex as MySqlExecption;
            // If there is a constraint violation error.
            // (I may have the wrong error number, please test.)
            if (sqlEx != null && sqlEx.Number == 1169) 
            {
                my = Form.ActiveForm as MyList;
                my.msg = new Message_Box();
                my.msg.Descrip.Text = "Record is already in the Database";
                my.msg.Title.Text = "Duplicate Record";
                my.msg.ShowDialog();
            } 
            else 
            {
                MessageBox.Show("" + ex);
            }
        }
        finally
        {
            ResumeLayout();
        }
    }
