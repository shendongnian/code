    public string EntityClassOpening(EntityType entity)
	{
		var stringsToMatch = new Dictionary<string,string> { { "POLICY_NO", "IPolicyNumber" }, { "UNIQUE_ID", "IUniqueId" } };
		return string.Format(
			CultureInfo.InvariantCulture,
			"{0} {1}partial class {2}{3}{4}",
			Accessibility.ForType(entity),
			_code.SpaceAfter(_code.AbstractOption(entity)),
			_code.Escape(entity),
			_code.StringBefore(" : ", _typeMapper.GetTypeName(entity.BaseType)),
			stringsToMatch.Any(o => entity.Properties.Any(n => n.Name == o.Key)) ? " : " + string.Join(", ", stringsToMatch.Join(entity.Properties, l => l.Key, r => r.Name, (l,r) => string.Format("{0}<{1}{2}>", l.Value,  r.TypeUsage.EdmType.Name, r.Nullable && r.TypeUsage.EdmType.Name!="String" ? "?" : ""))) : string.Empty);
	}
