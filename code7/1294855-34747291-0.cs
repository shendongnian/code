    public void seleciona_check()
        {
            bool changed = false; //boolean to see if something changed 
            bool compareTo=(bool)grid_lic.CurrentRow.Cells[3].Value; // take the first value as reference point
            for (int j = 7; j < grid_lic.ColumnCount - 1; j++) // for loop to check
            {
                if ((bool)grid_lic.CurrentRow.Cells[j].Value != compareTo)
                {
                    changed = true; 
                    SetAllValues(changed);
                    break; //no need to go on if there are true and false values
                }
            }
            if (changed == false) SetAllValues ( compareTo );
        }
    
        public void SetAllValues(bool toSet)
        {
            for (int j = 7; j < grid_lic.ColumnCount - 1; j++) // for loop to check
            {
                grid_lic.CurrentRow.Cells[j].Value = toSet;
            }
        }
