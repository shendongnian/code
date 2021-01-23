    public abstract class Criteria<T> where T : struct, IConvertible
    {
        public virtual T Field
        {
            get; set;
        }
        public string FieldData;
    }
    public class MyCriteria : Criteria<MyFieldsEnum>
    {
        MyFieldsEnum myfields;
        public override MyFieldsEnum Field
        {
            get
            {
                return myfields;
            }
            set
            {
                base.Field = value;
            }
        }
    }
