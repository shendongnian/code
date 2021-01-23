    /// <summary>
    /// Map using a resolve function that is passed the Items dictionary from mapping context
    /// </summary>
    public static void ResolveWithContext<TSource, TDest, TMember, TResult>(
        this IMemberConfigurationExpression<TSource, TDest, TMember> memberOptions, 
        Func<TSource, IDictionary<string, object>, TDest, TMember, TResult> resolver
    ) {
        memberOptions.ResolveUsing((src, dst, member, context) => resolver.Invoke(src, context.Items, dst, member));
    }
    public static TDest MapWithContext<TSource, TDest>(this IMapper mapper, TSource source, IDictionary<string, object> context, Action<IMappingOperationOptions<TSource, TDest>> optAction = null) {
        return mapper.Map<TSource, TDest>(source, opts => {
            foreach(var kv in context) opts.Items.Add(kv);
            optAction?.Invoke(opts);
        });
    }
