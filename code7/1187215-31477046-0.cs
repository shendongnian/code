    public class Parameter
    {
        public string Name { get; set; }
        public List<NormValue> Norms { get; set; }
    
        public NormValue this[string columnName]
        {
            get
            {
                /* You can use Linq if you prefer */
                foreach (NormValue normValue in Norms)
                {
                    if (StringComparer.OrdinalIgnoreCase.Compare(normValue.Definition.ColumnName, columnName) == 0)
                    {
                        return normValue;
                    }
                }
    
                NormValue newNormValue = new NormValue();
                newNormValue.Definition = new NormDefinition();
                newNormValue.Definition.ColumnName = columnName;
                newNormValue.Value = "Data is not available";
    
                Norms.Add(newNormValue);
    
                return newNormValue;
            }
        }
    }
