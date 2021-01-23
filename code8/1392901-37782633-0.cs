        public class MyListAttribute : ValidationAttribute
        {
                public override bool IsValid(object value)
                {
                        return value != null && (int)value != 2;
                }
        }
