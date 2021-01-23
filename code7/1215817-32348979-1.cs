    public static int ListCount;
    
            private void listBoxPackService_SelectedIndexChanged(object sender, EventArgs e)
            {
                int CurrCount;
    
                ListBox.SelectedObjectCollection col = listBoxPackService.SelectedItems;
                CurrCount = col.Count;
    
                if (CurrCount > ListCount)
                {
                    //Item Selected
                
                }
                else
                {
                    //Item DeSelected
                   if(CurrCount == 0)
                   {
                      //All Items Were Deselected
                   }
                }
    
                ListCount = CurrCount;
                
            }
