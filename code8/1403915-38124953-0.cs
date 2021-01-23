            DataSet EditT = new DataSet();
            DataSet ValidT = new DataSet();
            DataRow row;
            DataTable dtEdit = EditT.Tables[0];
            DataTable dtValid = ValidT.Tables[0];
            //Assuming columns match exactly;
            int rowIndex = 0; //Find the index of the row that is clicked.
            row = dtEdit.Rows[rowIndex];
            dtValid.Rows.Add(row.ItemArray); //NB: Must use .ItemArray as row belongs to dtEdit.
            dtEdit.Rows[rowIndex].Delete();
