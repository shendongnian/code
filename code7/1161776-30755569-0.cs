     void arrangeTableLayout()
     {
        int rowcount = 1;           
            tblPanel.ColumnCount=2;           
            tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i].Visible)
                {
                 var c1 = panel.Controls[i];
                 var c2 = GetNextControl(panel.Controls[i], true);
                 panel.Controls.Remove(c1);
                 i--;                            
                 panel.Controls.Remove(c2);
                 tblPanel.Controls.Add(c1, 0, rowcount);
                 tblPanel.Controls.Add(c2, 1, rowcount);
                 tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));                                          
                 rowcount++;
                 }                    
            }            
    } 
