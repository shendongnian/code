     public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> items = null;
            using (DbConnection cn = this.Connection)
            {
                cn.Open();
                items = cn.Query<T>("Select * from [TableName]");
            }
            return items;
        }
