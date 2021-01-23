        private void DBTLviewAfter_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            string toBeEditingStr = (string)e.NewValue;
            if(toBeEditingStr == "")
            {
                e.Cancel = true;
            }
        }
