    public string EntityClassOpening(EntityType entity)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1}partial class {2}{3}",
                Accessibility.ForType(entity),
                _code.SpaceAfter(_code.AbstractOption(entity)),
                _code.Escape(entity),
                _code.StringBefore(" : ", "BaseEntity"));
    
     public string Property(EdmProperty edmProperty)
        {
    		if (edmProperty.Name != "Id")
    		{
    			return string.Format(
    				CultureInfo.InvariantCulture,
    				"{0} {1} {2} {{ {3}get; {4}set; }}",
    				Accessibility.ForProperty(edmProperty),
    				_typeMapper.GetTypeName(edmProperty.TypeUsage),
    				_code.Escape(edmProperty),
    				_code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
    				_code.SpaceAfter(Accessibility.ForSetter(edmProperty)));
    		}
    		else
    		{
    			return String.Empty;
    		}
        }
