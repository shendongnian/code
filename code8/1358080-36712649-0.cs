    [HttpPost]
    public List<Product> GetByCode([FromBody]Item item)
            {
                using (var context = new DBContext())
                {
                    var getItem = (from s in context.objProduct where (s.ItemCode == item.Code) select s).ToList();
                    if (getItem!=null )
                    {
                        return getItem;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
