    public double[] GetMaxMinVals(Guid attrId)
        {
            double[] res = new double[2];
            using(entityContext = new SiteDBEntities())
            {
                res[0] = entityContext.ProductAttributes.Where(x=>x.AttrId == attrId).Select(x => x.Value).Cast<double>().Min();
            }
            return res;
        }
