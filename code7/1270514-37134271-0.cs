     ...
     //Turn on connection pooling
     //Note: the env handle controls pooling.  Only those connections created under that
     //handle are pooled.  So we have to keep it alive and not create a new environment
     //for   every connection.
     //
     retcode = UnsafeNativeMethods.SQLSetEnvAttr(
                this,
                ODBC32.SQL_ATTR.CONNECTION_POOLING,
                ODBC32.SQL_CP_ONE_PER_HENV,
                ODBC32.SQL_IS.INTEGER);
            switch(retcode) {
            case ODBC32.RetCode.SUCCESS:
            case ODBC32.RetCode.SUCCESS_WITH_INFO:
                break;
            default:
                Dispose();
                throw ODBC.CantEnableConnectionpooling(retcode);
            }
     ...
