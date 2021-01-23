                    ListView ProuctListView = new ListView();
                    for (int i = 0; i < GetProductByCategoryResultObject.Products.Count;i++ )
                    {
                        ProductsListing ProductsListingObject = new ProductsListing();
                        ProductsListingObject.ProductsListingLabel.Text = GetProductByCategoryResultObject.Products[i].ProductName;
                        if (GetProductByCategoryResultObject.Products[i].ProductThumbnail != null || GetProductByCategoryResultObject.Products[i].ProductThumbnail != "")
                        {
                            ProductsListingObject.ProductsListingImage.Source = new BitmapImage(new Uri(GetProductByCategoryResultObject.Products[i].ProductThumbnail,UriKind.Absolute));
                        }
                        ProuctListView.Items.Add(ProductsListingObject);
                    }
                    //Grid GridObject = new Grid();
                    //GridObject.Children.Add(ProuctListView);
                    (MainPagePivot.SelectedItem as PivotItem).Content = null;
                    //(MainPagePivot.SelectedItem as PivotItem).Content = GridObject;
                    (MainPagePivot.SelectedItem as PivotItem).Content = ProuctListView;
