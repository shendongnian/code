        private void showsPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Area.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Resize();
            fillGaps(showsPanel.ItemsPanelRoot as WrapGrid);
        }
        private void Resize()
        {
            var width = this.ActualWidth;
            var height = this.ActualHeight;
            var grid = (WrapGrid)showsPanel.ItemsPanelRoot;
            int numofColsOrig = grid.MaximumRowsOrColumns;
            if (width >= 2800) grid.MaximumRowsOrColumns = 8;
            if (width < 2800) grid.MaximumRowsOrColumns = 8;
            if (width < 2400) grid.MaximumRowsOrColumns = 7;
            if (width < 2000) grid.MaximumRowsOrColumns = 6;
            if (width < 1600) grid.MaximumRowsOrColumns = 5;
            if (width < 1200) grid.MaximumRowsOrColumns = 4;
            if (width < 800) grid.MaximumRowsOrColumns = 3;
            if (width < 400)
            {
                grid.MaximumRowsOrColumns = 2;
                if (Library.LibraryItems.Count >= 2) Area.Padding = new Thickness(0);
            }
            if (numofColsOrig != grid.MaximumRowsOrColumns)
            {
                fillGaps(grid);
            }
        }
        private void fillGaps(WrapGrid grid)
        {
            var libraryitems = Library.LibraryItems;
            if (libraryitems.Count < grid.MaximumRowsOrColumns && libraryitems.Count != 0)
            {
                int numOfItemsToFill = grid.MaximumRowsOrColumns - libraryitems.Count;
                Area.Padding = new Thickness { Right = (grid.ItemWidth * numOfItemsToFill) };
            }
        }
        private void maingrid_SizeChanged(object sender, SizeChangedEventArgs e) { Resize(); }
