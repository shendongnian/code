    public IEnumerable<Product> GetProductsByReportId(int rid)
        {
            using (var db = new MyContext())
            {
                var query = from b in db.table where b.rid == rid select b;
                if (query == null)
                {
                    return null;
                }
                return query.ToList();
            }
        }
