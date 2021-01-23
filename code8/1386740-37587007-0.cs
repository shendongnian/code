    public double[] GetMaxMinVals(Guid attrId)
            {
                double[] res = new double[2];
                using(entityContext = new SiteDBEntities())
                {
                    res[0] = entityContext.ProductAttributes.Where(x=>x.AttrId == attrId).Min(x => (double)x.Value);
                    res[1] = entityContext.ProductAttributes.Where(x => x.AttrId == attrId).Max(x => (double)x.Value);
                }
    
                return res;
            }
