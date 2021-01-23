            List<int>  bag = new List<int>();
            checkedNodes.ForEach(x=> bag.Add(x));
            data.OrderBy(x=>x.ParentNodeId).ToList().ForEach(item=>{
                if(bag.Contains(item.ParentNodeId)){
                    bag.Add(item.NodeId);
                    item.IsChecked = true;
                }
            });
