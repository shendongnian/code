    class QueryResultItem<T>
    {
        public T Entity { get; set; }
        public IEnumerable<AuditLog> Logs { get; set; }
    }
