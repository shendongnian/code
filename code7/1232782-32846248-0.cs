    public void MultiThreadMet (object IndexForSearch)
    {                
        int index = (int)IndexForSearch;
    
        while (isRunningForSearch)
        {
            try
            {
                if (index >= dataUrlList.Rows.Count)
                {
                    return;
                }
    
                DataGridViewRow row = dataUrlList.Rows[index];
                index++;
                //For just test i'm trying to add "test" in every cell[1] in datagridview
                dataUrlList.Invoke(new Action(() => row.Cells[1].Value = "test"));
            }
            catch
            {
            }                           
        }
    }
