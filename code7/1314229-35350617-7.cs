        private bool ValidateLinkedField(string fieldName)
        {
            //loop through the "levels" (e.g. Order / Customer / Name) validating that the fields/properties all exist
            Type currentType = ResultType;
            foreach (string currentLevel in DeQualifyFieldName(fieldName, ResultType))
            {
                MemberInfo match = (MemberInfo)currentType.GetField(currentLevel) ?? currentType.GetProperty(currentLevel);
                if (match == null) return false;
                currentType = match.MemberType == MemberTypes.Property ? ((PropertyInfo)match).PropertyType
                                                                       : ((FieldInfo)match).FieldType;
            }
            return true; //if we checked all levels and found matches, exit
        }
