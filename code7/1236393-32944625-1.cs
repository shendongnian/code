    public class Medium
    {
        public virtual Highest Parent { get; set; }
        public virtual ICollection<MyEnum> Children { get; set; }
    }
    public class HighestMap : ClassMap<Highest>
    {
        public HighestMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasMany(x => x.Children)
                .KeyColumn("parent_id")
                .AsList(i => i.Column("indexColumn"))
                .Component(c => 
                {
                    c.ParentReference(x => x.Parent);
                    
                    // remove Index property and use Highest.Children.IndexOf(medium)
                    c.Map(x => x.Children).CustomType<EnumCollectionAsStringUserType<MyEnum>>();
                });
        }
    }
    [Serializable]
    public class EnumCollectionAsStringUserType<TEnum> : IUserType
    {
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = (string)NHibernateUtil.String.Get(rs, names[0]);
            if (string.IsNullOrEmpty(value))
                return new List<TEnum>();
            return value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Parse).ToList();
        }
        private static TEnum Parse(string arg)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), arg);
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var collection = (IEnumerable<TEnum>)value;
            NHibernateUtil.String.Set(cmd, string.Join(",", collection), index);
        }
        public Type ReturnedType { get { return typeof(ICollection<TEnum>); } }
        public SqlType[] SqlTypes { get { return new[] { SqlTypeFactory.GetString(255) }; } }
        public object DeepCopy(object value)
        {
            return new List<TEnum>((IEnumerable<TEnum>)value);
        }
        bool IUserType.Equals(object x, object y)
        {
            return ((IEnumerable<TEnum>)x).SequenceEqual((IEnumerable<TEnum>)y);
        }
        int IUserType.GetHashCode(object x)
        {
            return ((IEnumerable<TEnum>)x).Aggregate(0, (a, v) => a << 8 + v.GetHashCode());
        }
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
        public bool IsMutable { get { return true; } }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
