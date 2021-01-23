    public IList<Layer> GetLayers()
            {
                IList<Layer> data = Db.GetLayers();
                IList<Layer> hierarcy = new List<Layer>();
    
                data.Where(x => x.ParentId == 0).ToList().ForEach(x => hierarcy.Add(x)); //get parent
    
                data.Where(a => a.ParentId != 0).ToList().
                    ForEach(a => 
                    {
                        hierarcy.Where(b => b.Id == a.ParentId).ToList().ForEach(c => c.ChildLayers.Add(a)); //get childrens
                    });
                
                return hierarcy;
            }
