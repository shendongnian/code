    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (association.IsForeignKey)
            {
                var constraint = association.Constraint;
                for (int i = 0; i < constraint.ToProperties.Count; ++i)
                {
                    int underscoreIndex = constraint.ToProperties[i].Name.IndexOf('_');
                    if (underscoreIndex > 0)
                    {
                        // change from EntityName_Id to id_EntityName
                        constraint.ToProperties[i].Name = "id_" + constraint.ToProperties[i].Name.Remove(underscoreIndex);
                    } 
                }
            }
        }
    }
