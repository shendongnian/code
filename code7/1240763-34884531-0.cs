        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                this.ultraDataSource1.Rows.Add(new object[] { i, i, i, i, i, i, i, i, i, i, i });
            }
            // Hook the paint event so we can wrap the cells the first time the grid paints. 
            // We can't do it here directly, because until the grid paints, there are no UIElements
            // and the columm measurements may be wrong. 
            this.ultraGrid1.Paint += UltraGrid1_Paint;
            
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand rootBand = layout.Bands[0];
            // ColumnLayout allows us to position the columns in a single data row on multiple
            // logical rows. 
            rootBand.RowLayoutStyle = RowLayoutStyle.ColumnLayout;
            // This code will be a lot more complex if we have to account for the possibility
            // that the vertical scrollbar may or may not be visible. So make it visible always
            // to spare us some headaches. 
            layout.Scrollbars = Scrollbars.Vertical;
            // This code doesn't account or multiple scroll regions to turn those off. 
            layout.MaxColScrollRegions = 1;
            layout.MaxRowScrollRegions = 1;
        }
        private void UltraGrid1_Paint(object sender, PaintEventArgs e)
        {
            // We only need to to this the first time, so unhook the Paint event. 
            this.ultraGrid1.Paint -= UltraGrid1_Paint;
            // Wrap the grid columns. 
            UltraGrid grid = (UltraGrid)sender;
            this.WrapGridRows(grid);
        }        
        private void ultraGrid1_Resize(object sender, EventArgs e)
        {
            // Wrap the grid columns. 
            UltraGrid grid = (UltraGrid)sender;
            this.WrapGridRows(grid);
        }
        private void WrapGridRows(UltraGrid grid)
        {
            UltraGridLayout layout = grid.DisplayLayout;
            // Determine the available Width of the grid.
            UIElement gridElement = layout.UIElement;
            UIElement rowColRegionIntersectionUIElement = gridElement.GetDescendant(typeof(RowColRegionIntersectionUIElement));
            int availableWidth = rowColRegionIntersectionUIElement.RectInsideBorders.Width;
            // X and y origins of each column in the ColumnLayout.
            int x = 0;
            int y = 0;
            // Keep track of the total width that has been used up on each row. 
            int totalUsedWidth = 0;
            // Loop through the columns.
            UltraGridBand band = layout.Bands[0];
            foreach (UltraGridColumn column in band.Columns)
            {
                // Get the width of the column. I added 2 here to account for borders. This doesn't seem
                // exactly right and I think there might be something else causing a slight shift here
                // but it's close enough.                 
                int cellWidth = column.CellSizeResolved.Width + 2;
                
                bool columnFitsOnCurrentLogicalRow = (totalUsedWidth + cellWidth) <= availableWidth;
                if (columnFitsOnCurrentLogicalRow)
                {
                    // Position this column in the current row.                     
                    column.RowLayoutColumnInfo.OriginX = x;
                    column.RowLayoutColumnInfo.OriginY = y;     
                    
                    // Increment x to the next position.                
                    x++;                    
                }
                else
                {
                    // Reset x and y to the beginning of the next row. 
                    x = 0;
                    y++;
                    // Position the column at the beginning of the next row. 
                    column.RowLayoutColumnInfo.OriginX = x;
                    column.RowLayoutColumnInfo.OriginY = y;
                    // Increment x to the next position.
                    x++;
                    // Reset TotalUsedWidth since we are starting a new row. 
                    totalUsedWidth = 0;
                }
                // The current column either got added to an existing row or a new row. 
                // Either way, we need to increase the total used width. 
                totalUsedWidth += cellWidth;
                // For reasons I won't go into here, the default Span is 2. Set it to 1 to 
                // make things simpler. 
                column.RowLayoutColumnInfo.SpanX = 1;
                column.RowLayoutColumnInfo.SpanY = 1;
            }
        }
