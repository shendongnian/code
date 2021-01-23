    class DataEntity : IDirtyCheckPropertiesProvider {
        [CheckDirty]
        public int Id { get; set; }
    
        public string Info { get; set; }
        string GetPropertyName(string dirtyProperty) {
            if (GetPropertyNameFromExpression(x => Id) == dirtyProperty)
                return GetPropertyNameFromExpression(x => Info);
            return null;
        }
    }
