    OracleParameter P_SO_LINES_TAB_ITEM = new OracleParameter();
    P_SO_LINES_TAB_ITEM.ParameterName = "p_so_lines_tab_item";
    P_SO_LINES_TAB_ITEM.OracleDbType = OracleDbType.NVarchar2;
    P_SO_LINES_TAB_ITEM.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    P_SO_LINES_TAB_ITEM.Size = 1000;
    P_SO_LINES_TAB_ITEM.Direction = ParameterDirection.Input;
