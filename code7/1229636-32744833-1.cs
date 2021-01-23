    public class MyCriteria : Criteria
    {
        MyFieldsEnum myfields;
        public override Enum Field
        {
            get
            {
                return myfields;
            }
            set
            {
                if (!(value is MyFieldsEnum))
                {
                    throw new InvalidOperationException("Cannot set enums other than MyFieldsEnum");
                }
                base.Field = value;
            }
        }
    }
