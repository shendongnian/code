    using(ISession session = SessionFactory.OpenSession())
             {
                 IList oUser = 
                     session
                     .CreateSQLQuery("SELECT * FROM USERS WHERE U_USERNAME = ?")
                     .AddEntity(typeof(Users))
                     .SetString(0, sUsername)
                     .List();
                 return false;
             }
