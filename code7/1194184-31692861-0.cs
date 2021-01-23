        public static string WildFindStatement( String search )
        {
            //REPLACE THE STRING WITH SQL INJECTION SAFE PARAMTERS
            //THATS ONLY FOR CONCEPT SHOWING (or at least a string buildeR)
            string sql = "select * from bla where 1=1 ";
            string  [] sa = search.Split(  new char[] {' '} );
            foreach ( var s in sa )
            {
                sql += ( " AND columBla LIKE '%" + s + "%'");
            }
            return sql;
        }
