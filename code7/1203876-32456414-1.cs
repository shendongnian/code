    public static class MapperExtensions
    {
        /// <summary>
        /// Creates a list from automapper projection. Also wraps delegate decompiler to supprt Computed Domain properties
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="projectionExpression"></param>
        /// <returns></returns>
        public static List<TDestination>
            ToList<TDestination>(this IProjectionExpression projectionExpression)
        {
            return projectionExpression.To<TDestination>().Decompile().ToList();
        }
    }
