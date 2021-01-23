    public class SPListItemPropertyMapper
    {
        private dynamic _expandoObject;
        public SPListItemPropertyMapper(SPListItem listItem)
        {
            _expandoObject = new ExpandoObject();
            foreach (SPField field in listItem.Fields)
            {               
                _expandoObject.Add(field.InternalName, listItem.GetFormattedValue(field.InternalName));
            }
        }
        public dynamic FieldValues
        {
            get { return _expandoObject; }
        }
    }
