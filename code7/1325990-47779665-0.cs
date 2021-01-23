    using Microsoft.SqlServer.Server; // SqlDataRecord and SqlMetaData
    using System;
    using System.Collections; // IEnumerator and IEnumerable
    using System.Collections.Generic; // general IEnumerable and IEnumerator
    using System.Data; // DataTable and SqlDataType
    using System.Data.SqlClient; // SqlConnection, SqlCommand, and SqlParameter
    using System.Web.UI.WebControls; // for Parameters.Convert... functions
    
    private static SqlDbType TypeToSqlDbType(Type t) {
        DbType dbtc = Parameters.ConvertTypeCodeToDbType(t.GetTypeCodeImpl());
        SqlParameter sp = new SqlParameter();
        // DbParameter dp = new DbParameter();
        // dp.DbType = dbtc;
        sp.DbType = dbtc;
        return sp.SqlDbType;
    }
