    DataTable partyDsTable = partiesDb.Tables["party"]; //partiesDb is DataSet object
        for (int i = 0; i < size; i++)// "size" does not look like it's set to anything. If "size" is 0, then the loop will not loop. 
        {
            
                partyDsTable.Rows.Add(new object[] {sth,"0","1"});//you should probably make the columns into the correct type if you are using integers.
           
        }
        System.Windows.Forms.MessageBox.Show(partyDsTable.Rows[0]["sth"].ToString());
        partiesDb.WriteXml(path);
