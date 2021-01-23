    public class JoinResult<TL, TR>
    {
        public TL Left { get; set; }
        public TR Right { get; set; }
    }
    public static IQueryable<JoinResult<TL, TR>> LeftJoin<TL, TR, TKey>(this IQueryable<TL> left, IQueryable<TR> right, Expression<Func<TL, TKey>> leftKeySelector, Expression<Func<TR, TKey>> rightKeySelector)
    {
        return left
            .GroupJoin(right, leftKeySelector, rightKeySelector, (l, rightGroup) => new { l, rightGroup = rightGroup.DefaultIfEmpty() })
            .SelectMany(z => z.rightGroup.Select(r => new JoinResult<TL, TR> { Left = z.l, Right = r }));
    }
    public static IQueryable<JoinResult<TL, TR>> RightJoin<TL, TR, TKey>(this IQueryable<TL> left, IQueryable<TR> right, Expression<Func<TL, TKey>> leftKeySelector, Expression<Func<TR, TKey>> rightKeySelector)
    {
        return right
            .GroupJoin(left, rightKeySelector, leftKeySelector, (r, leftGroup) => new { leftGroup = leftGroup.DefaultIfEmpty(), r })
            .SelectMany(z => z.leftGroup.Select(l => new JoinResult<TL, TR> { Left = l, Right = z.r }));
    }
