        for (int i = 0; i < sdr.FieldCount; i++)
        {
            bool val = Convert.ToBoolean(dr[i]);
            string colName = sdr.GetName(i);
            if (colName != "Name" && val)
            {
                CheckBox myChkBox = (CheckBox)Page.FindControl(colName);
                myChkBox.checked = val;
                
            }
        }
