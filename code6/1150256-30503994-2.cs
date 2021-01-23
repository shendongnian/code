        public enum SQL_INFO
        {
            DATA_SOURCE_NAME,
            DRIVER_NAME,
            DRIVER_VER,
            ODBC_VER,
            SERVER_NAME,
            SEARCH_PATTERN_ESCAPE,
            DBMS_NAME,
            DBMS_VER,
            IDENTIFIER_CASE,
            IDENTIFIER_QUOTE_CHAR,
            CATALOG_NAME_SEPARATOR,
            DRIVER_ODBC_VER,
            GROUP_BY,
            KEYWORDS,
            ORDER_BY_COLUMNS_IN_SELECT,
            QUOTED_IDENTIFIER_CASE,
            SQL_OJ_CAPABILITIES_30,
            SQL_SQL92_RELATIONAL_JOIN_OPERATORS,
            SQL_OJ_CAPABILITIES_20
        }
        public static string GetInfoStringUnhandled(OdbcConnection ocn, SQL_INFO info)
        {
            MethodInfo GetInfoStringUnhandled = ocn.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(c => c.Name == "GetInfoStringUnhandled");
            ParameterInfo SQL_INFO =
                GetInfoStringUnhandled.GetParameters()
                    .First(c => (c.ParameterType.ToString() == "System.Data.Odbc.ODBC32+SQL_INFO"));
            Array EnumValues = SQL_INFO.ParameterType.GetEnumValues();
            foreach (var enumval in EnumValues)
            {
                if (enumval.ToString() == info.ToString())
                {
                    return Convert.ToString(GetInfoStringUnhandled.Invoke(ocn, new object[] { enumval }));
                }
            }
            return "";
        }
        private static void Main(string[] args)
        {
            OdbcConnection ocn = new OdbcConnection("DSN=GENESIS");
            ocn.Open();
            Console.WriteLine(GetInfoStringUnhandled(ocn, SQL_INFO.DBMS_VER) + " " +
                              GetInfoStringUnhandled(ocn, SQL_INFO.DBMS_NAME));
        }
