    public static IEnumerable<TOuter> NotJoin<TOuter, TInner, TKey>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
        where TInner : class
        where TOuter : class
    {
        IEnumerable<TOuter> results = from o in outer join i in inner on outerKeySelector(o) equals innerKeySelector(i) into joinData from left in joinData.DefaultIfEmpty() where left == null select o;
        return results;
    }
    barcodesSource.NotJoin(barcodesTarget, x=> new {x.BARCODE, x.ITEM}, y=> new {y.BARCODE, y.ITEM});
