    private void ListView_ItemSelect(object sender, SelectedItemChangedEventArgs e)
            {
                var selectedItem = (MasterMenuItem)((ListView)sender).SelectedItem;
           
                MainPage mainPage = (App.Current.MainPage as MainPage);
                switch (selectedItem.KeyIndexName)
                {
                    case "MainPage":
                        mainPage.Detail = mainPage.MainPageDetail;
                        break;
                    case "AAA":
                        if(aaa==null)
                            aaa = new NavigationPage(new AaaPage());
                        mainPage.Detail = aaa;
                        break;
                    case "BBB":
                        if (bbb== null)
                            bbb = new NavigationPage(new BbbPage());
                        mainPage.Detail = bbb;
                        break;
                    case "CCC":
                        if (ccc == null)
                            ccc = new NavigationPage(new CccPage());
                        mainPage.Detail = ccc;
                        break;
                };
                mainPage.IsPresented = false;
            }
