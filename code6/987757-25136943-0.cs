            var list = new List<TreeModel>();
            for (int i = 0; i < 10000; i++)
            {
                var treeModel = new TreeModel();
                treeModel.Header = "Node 1";
                list.Add(treeModel);
            }
            MyTreeView.ItemsSource = list;
