    public class DynamicContractResolver : DefaultContractResolver {
        private readonly string[] props;
        public DynamicContractResolver(params string[] prop) {
            this.props = prop;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            IList<JsonProperty> retval = base.CreateProperties(type, memberSerialization);
            // retorna todas as propriedades que não estão na lista para ignorar
            retval = retval.Where(p => !this.props.Contains(p.PropertyName)).ToList();
            return retval;
        }
    }
