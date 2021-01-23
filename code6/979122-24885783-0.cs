    public static void SetUp(string _pScopeName, DbSyncTableDescription _pDbSyncTable, SqlConnection serverConn, SqlConnection clientConn)
            {
                // Create a scope named "_ITEM" and add tables to it.
                DbSyncScopeDescription productScope = new DbSyncScopeDescription(_pScopeName);
    
                // Define the Products table.
    
    
    
                // Add the Table to the scope object.    
                Collection<string> includeColumns = new Collection<string>();
                for (int i = 0; i < _pDbSyncTable.Columns.Count; i++)
                {
                    includeColumns.Add(_pDbSyncTable.Columns[i].UnquotedName);
                }
                DbSyncTableDescription productDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable(_pScopeName, includeColumns, serverConn);
                productScope.Tables.Add(productDescription);
                
                // Create a provisioning object for "_ITEM" and apply it to the on-premise database if one does not exist.
                SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, productScope);
                serverProvision.ObjectSchema = ".dbo";
    
                //serverProvision.Tables["[]."+ _pDbSyncTable.LocalName].AddFilterColumn("_WORKGROUPNAME");
                //serverProvision.Tables[_pDbSyncTable.LocalName].FilterClause = _CCompanyVar._WORKGROUPNAME;
                
                // Filter Rows for the ListPrice column
                serverProvision.Tables[ _pDbSyncTable.LocalName].AddFilterColumn("_WORKGROUPNAME");
                serverProvision.Tables[ _pDbSyncTable.LocalName].FilterClause = "[side].[_WORKGROUPNAME] = '" + _CCompanyVar._WORKGROUPNAME + "'";
    
                if (_CPubVar._Stop_bool)
                {
                    return;
                }
                if (!serverProvision.ScopeExists(_pScopeName))
                    serverProvision.Apply();
    
                // Provision the SQL client database from the on-premise SQL Server database if one does not exist.
                SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, productScope);
    
                if (_CPubVar._Stop_bool)
                {
                    return;
                }
                if (!clientProvision.ScopeExists(_pScopeName))
                    clientProvision.Apply();
    
            }
