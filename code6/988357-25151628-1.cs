    void AddSortImage(GridViewRow headerRow) 
    { 
         int iCol = GetSortColumnIndex();
         if (-1 == iCol) 
               return; 
    
         // Create the sorting image based on the sort direction.
    
         Image sortImage = new Image();
         if (SortDirection.Ascending == this.GridView1.SortDirection) 
    
    {             sortImage.ImageUrl = @"~\Images\BlackDownArrow.gif"; 
                   sortImage.AlternateText = "Ascending Order"; 
    }     else  
    {
                 sortImage.ImageUrl = @"~\Images\BlackUpArrow.gif";
                 sortImage.AlternateText = "Descending Order";
    }
          // Add the image to the appropriate header cell. 
            headerRow.Cells[iCol].Controls.Add(new LiteralControl("&nbsp;"));
            headerRow.Cells[iCol].Controls.Add(sortImage); 
    } 
    
    public int GetSortColumnIndex() 
    { 
          // Iterate through the Columns collection to determine the index 
          // of the column being sorted. 
          foreach (DataControlField field in GridView1.Columns) 
           { 
                 if (field.SortExpression == this.GridView1.SortExpression) 
                   { 
                      return this.GridView1.Columns.IndexOf(field); 
                    }
             } 
          return -1;
    }
