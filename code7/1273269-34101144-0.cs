    private void storeTesting(object sender, TextChangedEventArgs e)
        {
            List<Stores> storeTest = new List<Stores>();
            try
            {
                if (searchKeyword.Text != "")
                {
                    Debug.WriteLine(searchKeyword.Text);
                    foreach (Stores storeToShow in storesSource)
                    {
                        if (storeToShow.Name.Contains(searchKeyword.Text))
                        {
                            storeTest.Add(storeToShow);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine(searchKeyword.Text + "the text is null");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            var alphaKeyGroup = AlphaKeyGroup<Stores>.CreateGroups(storeTest, (Stores s) => { return s.Name; }, true);
            ListViewCollectionSource.Source = alphaKeyGroup;
        }
