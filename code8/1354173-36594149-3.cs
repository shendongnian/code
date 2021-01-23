        public abstract class ValueBase
        {
            // overrides object's ToString()
            public override string ToString()
            {
                return base.ToString();
            }
        }
        public class EmailAddress : ValueBase
        {
           ...
           // overrides ValueBase's ToString()
           public override string ToString()
           {
               return MailAddress.Address;
           }
        }
   
