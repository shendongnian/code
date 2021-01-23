    public class Aclass
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
    public class Bclass : Aclass
    {
        public Bclass(Aclass aInstance)
        {
            CopyPropertiesFromAltInstance(aInstance);
        }
        public void CopyPropertiesFromAltInstance(Aclass aInstance)
        {
            PropertyInfo[] aProperties = aInstance.GetType().GetProperties();
            PropertyInfo[] myProperties = this.GetType().GetProperties();
            foreach (PropertyInfo aProperty in aProperties)
            {
                foreach (PropertyInfo myProperty in myProperties)
                {
                    if (myProperty.Name == aProperty.Name && myProperty.PropertyType == aProperty.PropertyType)
                    {
                        myProperty.SetValue(this, aProperty.GetValue(aInstance));
                    }
                }
            }
        }
    }
