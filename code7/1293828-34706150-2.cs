    public class Class3 : Class1<Class3>    {
    {
        // ...
        protected override void Load(dynamic row)
        {
            // No need to check for null, it is enforced by the base class
            ID = Convert.ToInt64(row.ID);
            UID = Convert.ToInt64(row.UID);
            // ...
        }
    }
