         public class ComboBoxEditor : ITypeEditor
        {
            public void Attach(PropertyViewItem property, PropertyItem info)
            {
            }
            ComboBoxAdv cmb;
            public object Create(PropertyInfo propertyInfo)
            {
                cmb = new ComboBoxAdv();
                cmb.Items.Add("Curren");
                cmb.Items.Add("Currency");
                cmb.Items.Add("Scientific Notation");
                cmb.Items.Add("General Number");
                cmb.Items.Add("Number");
                cmb.Items.Add("Percent");
                cmb.Items.Add("Time");
                cmb.Items.Add("Date");
                return cmb;
            }
            public void Detach(PropertyViewItem property)
            {
                throw new NotImplementedException();
            }
       
    }
    CustomEditor ComboBoxEditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(string[]) };
            ComboBoxEditor.Editor = new ComboBoxPropertyGridSample.ComboBoxEditor();
