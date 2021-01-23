        public interface IValidator
        {
            void Validate(object value);
        }
        public class NumberValidator : IValidator
        {
            public void Validate(object value)
            {
                //implementation
            }
        }
        public class DecimalValidator : IValidator
        {
            public void Validate(object value)
            {
                //implementation
            }
        }
        public class DatetimeValidator : IValidator
        {
            public void Validate(object value)
            {
                //implementation
            }
        }
        private void Validate(IValidator dataType, object value)
        {
            dataType.Validate(value);
        }
