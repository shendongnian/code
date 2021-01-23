c#
public interface IMapper<in TSource, in TResult>
    where TResult : new() {
        void Map(TSource source, TResult result);
}
This describes a generic interface with two input types `TSource` and `TResult`, the latter having a `new()` constraint so we can manufacture it programmatically. 
Now let's add some functionality, for mapping one-to-one, one-to-one with nulls and many-to-many:
c#
public static class IMapperExtensions {
    public static TResult Map<TSource, TResult>(this IMapper<TSource, TResult> mapper, TSource source)
        where TResult : new() {
        TResult result = new TResult();
        mapper.Map(source, result);
        return result;
    }
    public static TResult MapAllowNull<TSource, TResult>(this IMapper<TSource, TResult> mapper, TSource source)
        where TResult : new() {
        if (source == null) {
            return default(TResult);
        }
        return mapper.Map(source);
    }
    public static IEnumerable<TResult> MapCollection<TSource, TResult>(this IMapper<TSource, TResult> mapper, IEnumerable<TSource> source)
        where TResult : new() {
        if (source == null) {
            yield return default(TResult);
        }
        else {
            foreach (var s in source) {
                yield return mapper.Map(s);
            }
        }
    }
}
An the implementation:
c#
class Foo {
    public string name { get; set; }
    public int rank { get; set; }
    public bool isDelected { get; set; }
}
class FooView {
    public string name { get; set; }
    public int rank { get; set; }
}
class FooToFooView : IMapper<Foo, FooView> {
    public void Map(Foo source, FooView result) {
        result.name = source.name;
        result.rank = source.rank
    }
}
> Whatever you do, resist the urge to define a static method for this. Elect either the constructor, or the mapper.
