    internal abstract class TransformBase<TOriginal, TConverted>
    {
        protected abstract Expression<Func<TOriginal, TConverted>> Expression { get; }
        public IQueryable<TConverted> Transform(IEnumerable<TOriginal> value)
        {
            return value.AsQueryable().Select(Expression);
        }
    }
    public static class TransformCompany
    {
        public static IQueryable<CompanyHeader> AsHeaders(this IEnumerable<Organization> companies)
        {
            return header.Transform(companies);
        }
    }
