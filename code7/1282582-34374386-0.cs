    public class ClsAggModel {
        public ClsAggModel() {
            foreach (PropertyInfo prop in this.GetType().GetProperties()) {
                var newValue = Activator.CreateInstance(prop.GetType());
                prop.SetValue(this, newValue);
            }
        }
    
       public clsItem1 pProp1{ get; set; }
       public clsItem2 pProp2{ get; set; }
