    class RowToRoleRuleConverter : CustomCreationConverter<Row>
    {
        public override Row Create(Type objectType)
        {
            if (objectType.IsAssignableFrom(typeof(RowRule)))
                return Activator.CreateInstance<RowRule>();
            return (Row)Activator.CreateInstance(objectType);
        }
    }
