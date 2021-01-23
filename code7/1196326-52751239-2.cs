    public static readonly string USER_CONTEXT_KEY = "USER";
    /// <summary>
    /// Map using a resolve function that is passed a user from the
    /// Items dictionary in the mapping context
    /// </summary>
    public static void ResolveWithUser<TSource, TDest, TMember, TResult>(
        this IMemberConfigurationExpression<TSource, TDest, TMember> memberOptions,
        Func<TSource, User, TResult> resolver
    ) {
        memberOptions.ResolveUsing((src, dst, member, context) =>
            resolver.Invoke(src, context.Items[USER_CONTEXT_KEY] as User));
    }
    /// <summary>
    /// Execute a mapping from the source object to a new destination
    /// object, with the provided user in the context.
    /// </summary>
    public static TDest MapForUser<TSource, TDest>(
        this IMapper mapper,
        TSource source,
        User user,
        Action<IMappingOperationOptions<TSource, TDest>> optAction = null
    ) {
        var context = new Dictionary<string, object> { { USER_CONTEXT_KEY, user } };
        return mapper.MapWithContext(source, context, optAction);
    }
