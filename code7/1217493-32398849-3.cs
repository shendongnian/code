    public MyTreeViewItem<Level0ViewModel,object> TreeModel
            {
                get
                {
                    MyTreeViewItem<Level0ViewModel,object> src = new MyTreeViewItem<Level0ViewModel, object>("Root", null);
                    src.Children.Add(new Level0ViewModel("toto", new XmlDocument()));
                    return src;
                }
            }
