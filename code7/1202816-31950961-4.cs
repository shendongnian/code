      private List<Control> children;
     
      public CustomLayout()
      {
          children = new List<Control>();      
      }
      public void AddChild(Control childToAdd)
      {
          children.Add(childToAdd);
          // TODO: Determine if new layout is needed.
      }
      public void RemoveChild(Control childToRemove)
      {
          children.Remove(childToRemove);
          // TODO: Determine if new layout is needed.
      }
      // Call to update the layout.
      private void PerformLayout(int columns, int rows)
      {
         Grid layoutGrid = new Grid();
         // TODO: Programmatically build grid layout.
         RowDefinition row = new RowDefinition();
         row.Height = 100;
         layoutGrid.Rows.Add(row);
         // Methods for layout:
         // Grid.SetRow(rowID, childControl);
         // Grid.SetColumn(columnID, childControl);
         // Note: This may produce some flashing on resize, so there may be better ways to remove/add the grid such as redoing rows and columns instead.
         Controls.Clear();
         Controls.Add(layoutGrid);
      }
      // Should be called when the window or parent resizes. I can't remember the events in question.
      public void OnResize()
      {
         int columns;
         int rows;
         // TODO: Calculate columns/rows
         PerformLayout(columns, rows);
      }
