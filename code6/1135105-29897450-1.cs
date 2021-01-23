    /// <summary>
    /// QueryOver&lt;TRoot,TSubType&gt; is an API for retrieving entities by composing
    /// <see cref="Criterion.Expression" /> objects expressed using Lambda expression syntax
    /// </summary>
    /// <remarks>
    /// <code>
    /// IList&lt;Cat&gt; cats = session.QueryOver&lt;Cat&gt;()
    /// 	.Where( c =&gt; c.Name == "Tigger" )
    ///		.And( c =&gt; c.Weight > minWeight ) )
    ///		.List();
    /// </code>
    /// </remarks>
    public interface IQueryOver<TRoot,TSubType> : IQueryOver<TRoot>
    {
       ...
