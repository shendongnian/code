    abstract class GenericRepository<T>
    {
        public List<T> GetQuery<TKey>(
            Func<T, bool> conditionFieldName, 
            Func<T, TKey> orderFieldName)
        {
            var lstResult = Repository()
                .Where(conditionFieldName)
                .OrderBy(orderFieldName)
                .ToList();
            return lstResult;
        }
        private IEnumerable<T> Repository()
        {
            throw new NotImplementedException();
        }
    }
    class TransactionDetailRepository : GenericRepository<TransactionDetail>
    {
    }
