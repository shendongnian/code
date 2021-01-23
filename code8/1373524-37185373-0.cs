    public class Helper
    {
        public static void CopyItem<T>(BigClass source, T target)
        {
            // Need a way to rename the backing-field name to the property Name ("<A>k__BackingField" => "A")
            Func<string, string> renameBackingField = key => new string(key.Skip(1).Take(key.IndexOf('>') - 1).ToArray());
    
            // Get public source properties (change BindingFlags if you need to copy private memebers as well)
            var sourceProperties = source.GetType().GetProperties().ToDictionary(item => item.Name);
            // Get "missing" property setter's backing field
            var targetFields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField).ToDictionary(item => renameBackingField(item.Name));
    
            // Copy properties where target name matches the source property name
            foreach(var sourceProperty in sourceProperties)
            {
                if (targetFields.ContainsKey(sourceProperty.Key) == false)
                    continue; // No match. skip
    
                var sourceValue = sourceProperty.Value.GetValue(source);
                targetFields[sourceProperty.Key].SetValue(target, sourceValue);
            }
        }
    }
