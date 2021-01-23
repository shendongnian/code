    cbTipos.DisplayMember = "Description";
    cbTipos.ValueMember = "Value";
    cbTipos.DataSource = Enum.GetValues(typeof(TiposTrabajo))
        .Cast<Enum>()
        .Select(value => new
        {
            (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
            value
        })
        .OrderBy(item => item.value)
        .ToList();
