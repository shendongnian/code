    public static int ServiceListCount;
    
            private void listBoxPackService_SelectedIndexChanged(object sender, EventArgs e)
            {
                int CurrCount;
    
                ListBox.SelectedObjectCollection col = listBoxPackService.SelectedItems;
                CurrCount = col.Count;
    
                if (CurrCount > ServiceListCount)
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
    
                ServiceListCount = CurrCount;
                
            }
