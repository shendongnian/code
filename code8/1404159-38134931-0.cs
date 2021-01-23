    // won't work because the expression will be built with INamedObject as the
    // type, rather than the actual Entity type
    public static IQueryable<T> ComplexWhere<T>(
       [NotNull] this IQueryable<T> pQueryable,
       [NotNull] string pSearchValue
    )
    where T : INamedObject {
       return
          pQueryable
          .Where(item =>
             string.IsNullOrEmpty(pSearchValue)
             || item.Name.Contains(pSearchValue)
          );
    }
