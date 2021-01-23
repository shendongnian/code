        protected IQueryable<T> ApplyFilters<T>(IQueryable<T> data)
        {
            if (data == null) return null;
            IQueryable<T> retVal = data.AsQueryable();
            //get all the fields and properties that have search attributes specified
            var fields = GetType().GetFields().Cast<MemberInfo>()
                                  .Concat(GetType().GetProperties())
                                  .Where(f => f.GetCustomAttribute(typeof(LinkedField)) != null)
                                  .Where(f => f.GetCustomAttribute(typeof(Comparison)) != null);
            //loop through them and generate expressions for validation and searching
            try
            {
                foreach (var f in fields)
                {
                    var value = f.MemberType == MemberTypes.Property ? ((PropertyInfo)f).GetValue(this) : ((FieldInfo)f).GetValue(this);
                    if (value == null) continue;
                    Type t = f.MemberType == MemberTypes.Property ? ((PropertyInfo)f).PropertyType : ((FieldInfo)f).FieldType;
                    retVal = new SearchFilter<T>
                    {
                        SearchValue = value,
                        ApplySearchCondition = GetValidationExpression(t),
                        SearchExpression = GetSearchExpression<T>(GetTargetField(f), ((Comparison)f.GetCustomAttribute(typeof(Comparison))).Type, value)
                    }.Apply(retVal); //once the expressions are generated, go ahead and (try to) apply it
                }
            }
            catch (Exception ex) { throw (ErrorInfo = ex); }
            return retVal;
        }
