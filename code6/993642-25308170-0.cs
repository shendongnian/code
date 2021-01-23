    //Event for checking if the MouseUp event triggered
        private System.Threading.AutoResetEvent _stopTrigger;
        private void Tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedTile = sender as DevExpress.Xpf.LayoutControl.Tile;
            string ButtonToProductsCategoriesViewEnabled = ButtonToProductsCategoriesView.Visibility.ToString();
            int wcatpsn = Convert.ToInt32(selectedTile.Uid);
            App.Current.Properties["selectedTile_wcatpsn"] = wcatpsn;
            App.Current.Properties["selectedTile"] = selectedTile;
            if (ButtonToProductsCategoriesViewEnabled != "Visible")
            {
                if (this._stopTrigger == null)
                {
                    this._stopTrigger = new System.Threading.AutoResetEvent(false);
                                      
                }
                Action openMenuProcess = new Action(this.OpenMenuAfterTime);
                //Executes openMenuProcess on a differnet thread
                openMenuProcess.BeginInvoke(null, null);
            }
        }
        private void Tile_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this._stopTrigger != null)
            {
                // Sends the signal to the ShowPopupAfterTime that it should NOT display the pop up
                // IIt will make WaitOne return true and not go into the if statement
                this._stopTrigger.Set();
            }
            //Get selected Tile
            var selectedTile = sender as DevExpress.Xpf.LayoutControl.Tile;
            int wcatpsn = Convert.ToInt32(selectedTile.Uid);
            string connString = App.Current.Properties["connString"].ToString();
            using (TabletEntities db =
            new TabletEntities(connString))
            {
                List<Get_ProductsCategories_sp_Result> ProductsSubCategoriesList = db.Get_ProductsCategories_sp(wcatpsn).ToList<Get_ProductsCategories_sp_Result>();
                //Checks for sub categories
                if (ProductsSubCategoriesList.Count != 0)
                {
                    //If there are sub categories navigates to ProductsCategoriesPage
                    var MainFrame = DevExpress.Xpf.Core.Native.LayoutHelper.FindParentObject<NavigationFrame>(this);
                    ProductsCategoriesView ProductsCategoriesPage = new ProductsCategoriesView();
                    MainFrame.Navigate(ProductsCategoriesPage, wcatpsn);
                    App.Current.Properties["ButtonToProductsCategoriesView"] = "active";
                }
                else
                {
                    App.Current.Properties["ProductsSubCategories_wcatpsn"] = wcatpsn;
                    //If there arent sub categories navigates to ProductsPage
                    var MainFrame = DevExpress.Xpf.Core.Native.LayoutHelper.FindParentObject<NavigationFrame>(this);
                    ProductsView ProductsPage = new ProductsView();
                    MainFrame.Navigate(ProductsPage, wcatpsn);
                }
            }
        }
        //Runs timer and Enables ContextMenu after 2 seconds
        private void OpenMenuAfterTime()
        {
            // Will enter the if after 2 seconds
            if (!this._stopTrigger.WaitOne(2000))
            {
                var selectedTile = App.Current.Properties["selectedTile"] as DevExpress.Xpf.LayoutControl.Tile;
                 TileLayoutControlProductsCategories.Dispatcher.Invoke(new Action(() =>
                {
                    (selectedTile).ContextMenu.IsEnabled = true;
                    (selectedTile).ContextMenu.PlacementTarget = (selectedTile);
                    (selectedTile).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                    (selectedTile).ContextMenu.IsOpen = true;
                }));
            }
        }
