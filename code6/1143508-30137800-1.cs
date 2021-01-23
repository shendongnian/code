    abstract class GenericRepository
    {
        protected List<T> GetQuery<T, TKey>(
            Func<T, bool> conditionFieldName,
            Func<T, TKey> orderFieldName)
        {
            var lstResult = Repository<T>()
                .Where(conditionFieldName)
                .OrderBy(orderFieldName)
                .ToList();
            return lstResult;
        }
        private IEnumerable<T> Repository<T>()
        {
            throw new NotImplementedException();
        }
    }
    class TransactionDetailRepository : GenericRepository
    {
        public List<TransactionDetail> GetQuery<TKey>(
            Func<TransactionDetail, bool> conditionFieldName,
            Func<TransactionDetail, TKey> orderFieldName)
        {
            return base.GetQuery(conditionFieldName, orderFieldName);
        }
    }
