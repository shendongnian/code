        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
        dgv_calendrier.Columns.Add(imageCol);             //Andd new image columns to grid view
        int number_of_rows = dgv_calendrier.RowCount;
        for (int i = 0; i < number_of_rows; i++)
        {
                if (dgv_calendrier.Rows[i].Cells[1].Value.ToString() == "true")
                 
                Bitmap img = new Bitmap(@" dgv_calendrier.Rows[i].Cells["logo_dom"].Value.ToString()"); // get iamge location and conver to bit map.
                dgv_calendrier.Rows.Add();
                dgv_calendrier.Rows[i].Cells[7].Value = img; //set you newly added colomun
     
         }
 
