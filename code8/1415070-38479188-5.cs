    public class MapBuildKeyToDefaultPolicy : IBuildKeyMappingPolicy
    {
        private readonly Type _typeFrom;
        private readonly Type _typeTo;
        public MapBuildKeyToDefaultPolicy(Type typeFrom, Type typeTo)
        {
            this._typeFrom = typeFrom;
            this._typeTo = typeTo;
        }
        public NamedTypeBuildKey Map(NamedTypeBuildKey buildKey, IBuilderContext context)
        {
            if (buildKey.Type == this._typeFrom)
                return new NamedTypeBuildKey(this._typeTo);
            throw new InvalidOperationException();
        }
    }
