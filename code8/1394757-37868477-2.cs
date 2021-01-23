     public ActionResult DisplayTree()
            {
                IList<KendoTreeViewItem> flatList = GetFlatList();//your method to get list.
                IList<KendoTreeViewItem> tree = flatList.ToKendoTree();
                return View(tree);
            }
