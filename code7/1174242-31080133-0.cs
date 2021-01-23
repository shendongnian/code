    public class ObjectResult<T> : ObjectResult, IEnumerable<T>, IEnumerable, IDbAsyncEnumerable<T>, IDbAsyncEnumerable
    {
        // Summary:
        //     This constructor is intended only for use when creating test doubles that
        //     will override members with mocked or faked behavior. Use of this constructor
        //     for other purposes may result in unexpected behavior including but not limited
        //     to throwing System.NullReferenceException.
        protected ObjectResult();
