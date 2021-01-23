    static class ListItemExtensions
    {
       public static bool TryValidateAndUpdateChoiceFieldValue(this ListItem item, string fieldName, string fieldValue)
       {
            var ctx = item.Context;
            var field = item.ParentList.Fields.GetByInternalNameOrTitle(fieldName);
            ctx.Load(field);
            ctx.ExecuteQuery();
            var choiceField = ctx.CastTo<FieldChoice>(field);
            if (!choiceField.FillInChoice)
            {
                var allowedValues = choiceField.Choices;
                if (!allowedValues.Contains(fieldValue))
                {
                    return false;
                }
            }
            item.Update();
            return true;
        }
    }
