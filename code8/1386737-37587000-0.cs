    public double[] GetMaxMinVals(Guid attrId)
        {
            double[] res = new double[2];
            using(entityContext = new SiteDBEntities())
            {
                res[0] = entityContext.ProductAttributes.Where(x=>x.AttrId == attrId).Cast<double>(x => x.Value).Min(x => x.Value);
            }
            return res;
        }
