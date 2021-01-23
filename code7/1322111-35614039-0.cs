        [DataContractAttribute]
        public class jQGridResult<T>
        {
            [DataMember]
            int total;
            [DataMember]
            int page;
            [DataMember]
            int records;
            [DataMember]
            List<T> rows;
            public jQGridResult(int totalPages, int page, int totalRecords, IQueryable<T> queryable)
            {
                // TODO: Complete member initialization
                this.total = totalPages;
                this.page = page;
                this.records = totalRecords;
                this.rows = queryable.ToList();
            }
        }
