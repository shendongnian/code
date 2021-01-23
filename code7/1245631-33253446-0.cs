    private void GetTreeViewData()
            {
                List<Heirachi> result = new List<Heirachi>();
                //get all heirachi
                using (var c = new IWHSMacsteelEntities())
                {
                   result  = (from p in c.Products
                                 from ct in c.ConsultationTypes
                                 where p.Id == ct.ProductId
                                 orderby p.Id
                                 select new Heirachi
                                 {
                                     Name = p.Name,
                                     Code = ct.Code,
                                     ConsTypeDesc = ct.Name
                                 }).ToList();
    
    
                 
                }
                //distinct product
                var distinctResult = result.Select(s=>s.Name).Distinct();          
    
                //populate parent treeview
                TreeViewItem rootItem = new TreeViewItem();
                RootItem root = new RootItem();
                
                root.Name = "Features";
                rootItem.Header = root;
                productTreeView.Items.Add(rootItem);
    
    
                foreach (var dr in distinctResult)
                {
                    TreeViewItem item = new TreeViewItem();
                    item.Header = dr.ToString();
                    //item.Items.Add("*");
                    rootItem.Items.Add(item);
    
                   //add children
                    result.Where(s => s.Name == dr.ToString()).Select(s => s.ConsTypeDesc).ToList().ForEach(i =>
                        {
                            TreeViewItem childItem = new TreeViewItem();
                            childItem.Header = i.ToString();
                            //item.Items.Add("*");
                            item.Items.Add(childItem);
                            
                        });
    
                }
                rootItem.IsExpanded = true;
            }
