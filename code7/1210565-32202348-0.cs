    namespace TestSite.Business.EditorDescriptors
    {
        using EPiServer.Shell.ObjectEditing;
    
        public class EnumSelectionFactory<TEnum, TUnderlying> : ISelectionFactory
        {
            public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
            {
                var values = Enum.GetValues(typeof(TEnum));
    
                return (from object value in values select new SelectItem { Text = this.GetValueName(value), Value = Convert.ChangeType(value, typeof(TUnderlying)) }).OrderBy(x => x.Text);
            }
    
            private string GetValueName(object value)
            {
                return Enum.GetName(typeof(TEnum), value);
            }
        }
    } 
