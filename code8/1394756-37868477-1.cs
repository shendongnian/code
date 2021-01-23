     public static class KendoTreeHelpers
        {
            public static List<KendoTreeViewItem> ToKendoTree(this IList<KendoTreeViewItem> flatList)
            {
                Dictionary<long, KendoTreeViewItem> dic = flatList.ToDictionary(n => n.ItemId, n => n);
                var rootNodes = new List<KendoTreeViewItem>();
                foreach (var node in flatList)
                {
                    if (String.IsNullOrEmpty(node.ChildrenIds))
                    {
                        node.Items = null;
                    }
                    if (node.ParentId.HasValue)
                    {
                        var parent = dic[node.ParentId.Value];
                        node.ParentId = parent.ItemId;
                        parent.Items.Add(node);
                    }
                    else
                    {
                        rootNodes.Add(node);
                    }
                }
                return rootNodes;
            }
        }
