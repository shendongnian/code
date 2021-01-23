    /* Used by NHibernate to cast between string and type-safe-enum */
    public class MyCustomEnumType : IUserType
    {
        
        ...
        
        public SqlType[] SqlTypes
        {
            get { 
                return new[] {                   
                    // not working for NHibernate 4.1
                    //NHibernateUtil.String.SqlType 
                    SqlTypeFactory.GetString(200)
                }; 
            }
        }        
        
        ...
    }
