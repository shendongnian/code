    public class Field<T>
    {
        public Field(Expression<Func<T, object>> field, bool sortField = false, string displayName = null)
        {
            //get & validate member
            MemberExp = field.Body is UnaryExpression ? ((UnaryExpression)field.Body).Operand as MemberExpression
                                                      : (MemberExpression)field.Body;
            
            Field = MemberExp?.Member;
            if (Field == null) throw new ArgumentException("Field expression is not a member.");
            
            //set field type
            switch (Field.MemberType)
            {
                case MemberTypes.Property:
                    PropertyInfo p = (PropertyInfo)Field;
                    FieldType = p.PropertyType;
                    break;
                case MemberTypes.Field:
                    FieldInfo f = (FieldInfo)Field;
                    FieldType = f.FieldType;
                    break;
                default:
                    throw new Exception("Unsupported member type detected.");
            }
            //store input values
            FieldExpression = field;
            SortField = sortField;
            DisplayName = displayName ?? Field.Name;
        }
        public bool SortField { get; set; }
        public string DisplayName { get; private set; }
        public MemberExpression MemberExp { get; private set; }
        public Expression<Func<T, object>> FieldExpression { get; private set; }
        public Func<T, object> GetValue => FieldExpression.Compile();
        public Type FieldType { get; set; }
        /// <summary>
        /// Gets the full field name, i.e o => o.Customer.CustomerName returns "Customer.CustomerName"
        /// </summary>
        public string UnqualifiedFieldName
        {
            get
            {
                var stringExp = MemberExp.ToString();
                var paramEnd = stringExp.IndexOf('.') + 1;
                return  stringExp.Substring(paramEnd);
            }
        }
    }
