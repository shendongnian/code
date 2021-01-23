public class LeftJoinResult<TLeft, TRight>
{
    public TLeft Left { get; set; }
    public TRight Right { get; set; }
}
public class RightJoinResult<TRight, TLeft>
{
    public TRight Right { get; set; }
    public TLeft Left { get; set; }
}
public static IQueryable<LeftJoinResult<TLeft, TRight>> LeftJoin<TLeft, TRight, TKey>(this IQueryable<TLeft> left, IQueryable<TRight> right, Expression<Func<TLeft, TKey>> leftKeySelector, Expression<Func<TRight, TKey>> rightKeySelector)
    where TRight : class
{
    return left.GroupJoin(right, leftKeySelector, rightKeySelector, (l, r) => new
    {
        Left = l,
        Matches = r.DefaultIfEmpty(),
    })
    .SelectMany(j => j.Matches, (j, m) => new LeftJoinResult<TLeft, TRight>
    {
        Left = j.Left,
        Right = m,
    });
}
public static IQueryable<RightJoinResult<TRight, TLeft>> RightJoin<TRight, TLeft, TKey>(this IQueryable<TRight> right, IQueryable<TLeft> left, Expression<Func<TRight, TKey>> rightKeySelector, Expression<Func<TLeft, TKey>> leftKeySelector)
    where TLeft : class
{
    return right.GroupJoin(left, rightKeySelector, leftKeySelector, (r, l) => new
    {
        Right = r,
        Matches = l.DefaultIfEmpty(),
    })
    .SelectMany(j => j.Matches, (j, m) => new RightJoinResult<TRight, TLeft>
    {
        Right = j.Right,
        Left = m,
    });
}
