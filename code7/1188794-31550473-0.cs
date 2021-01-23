    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using gudusoft.gsqlparser;
    using gudusoft.gsqlparser.Units;
    namespace Custom.Data {
    
        class TokenizeQuery {
    
            public static List < String > TableNames = new List < String > ();
            public static List < String > ColumnNames = new List < String > ();
            // public static String inputSql = "SELECT * FROM ABC";
            public void exec(String query) {
                TableNames.Clear();
                ColumnNames.Clear();
                getTableColumn _new = new getTableColumn();
                _new.GetTableColumnName(query);
            }
    
            public void print() {
                Console.WriteLine("**************************************************************");
                Console.Write("TABLES\n\n");
                TableNames.ForEach(i => Console.Write("{0}\n", i));
                Console.Write("COLUMNS\n\n");
                ColumnNames.ForEach(i => Console.Write("{0}\n", i));
                Console.WriteLine("**************************************************************");
            }
    
    
            #
            region tableInfo
            class tableInfo {
                public TCustomSqlStatement stmt;
                public TSourceToken database, schema, table, tableAlias;
    
                public string getDatabaseName() {
                    if (database == null) {
                        return "";
                    } else {
                        return database.AsText;
                    }
                }
    
                public string getSchemaName() {
                    if (schema == null) {
                        return "";
                    } else {
                        return schema.AsText;
                    }
                }
    
                public string getTableName() {
                    if (table == null) {
                        return "";
                    } else {
                        return table.AsText;
                    }
                }
    
                public string getTableAliasName() {
                    if (tableAlias == null) {
                        return "";
                    } else {
                        return tableAlias.AsText;
                    }
                }
    
                public tableInfo(TCustomSqlStatement s) {
                    stmt = s;
                }
            }
    
            #
            endregion
    
            # region columnInfo
            class columnInfo {
                public tableInfo table;
                public TSourceToken column;
                public string columnAlias;
                //public int lineNo, columnNo;
                public TLzOwnerLocation location;
                public TLzExpression columnExpr;
                public columnInfo(tableInfo t) {
                    table = new tableInfo(t.stmt);
                    table.database = t.database;
                    table.schema = t.schema;
                    table.table = t.table;
                    table.tableAlias = t.tableAlias;
                }
            }
    
            #
            endregion
    
            class getTableColumn {
    
                static List < columnInfo > columnInfos = null;
    
                static bool bSortColumn = false;
    
                /**
                 * This is a sample callback function used by SQL parser to determine
                 * relationship between table and column like this SQL:
                 * *
                 * SELECT
                 * Quantity,b.Time,c.Description
                 * FROM
                 * (SELECT ID,Time FROM bTab) b
                 * INNER JOIN aTab a on a.ID=b.ID
                 * INNER JOIN cTab c on a.ID=c.ID
                 * 
                 * column: Quantity will be linked to table: cTab with the help of this
                 * callback function.
                 * otherwise, column: Quantity will be linked to table: aTab by default
                 * 
                 */
                private static bool metadataTableColumn(Object sender, string pSchema, string pTable, string pColumn) {
                    string[, ] columns = new string[3, 3] {
                        {
                            "dbo", "subselect2table1", "s2t1a1"
                        }, {
                            "dbo", "subselect3table1", "Quantity2"
                        }, {
                            "dbo", "subselect3table2", "s3t1a1"
                        }
                    };
    
                    bool bSchema = false, bTable = false, bColumn = false;
                    for (int i = 0; i < 3; i++) {
                        if (pSchema == "") bSchema = true;
                        else bSchema = pSchema.Equals(columns[i, 0], StringComparison.OrdinalIgnoreCase);
                        if (!bSchema) continue;
    
                        bTable = pTable.Equals(columns[i, 1], StringComparison.OrdinalIgnoreCase);
                        if (!bTable) continue;
    
                        bColumn = pColumn.Equals(columns[i, 2], StringComparison.OrdinalIgnoreCase);
                        if (!bColumn) continue;
    
                        break;
                    }
                    return bColumn;
                }
    
                public void GetTableColumnName(String inputSql) {
    
    
    
                    columnInfos = new List < columnInfo > ();
    
                    TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle); //DbVMssql
                    sqlparser.SqlText.Text = inputSql;
    
                    // please use your own function to check table column relation using meta
                    // information from database
    
                    //sqlparser.OnMetaDatabaseTableColumn += metadataTableColumn;
    
                    int ret = sqlparser.Parse();
    
                    if (ret != 0) {
                        Console.WriteLine(sqlparser.ErrorMessages);
                        return;
                    }
    
    
    
                    for (int i = 0; i < sqlparser.SqlStatements.Count(); i++) {
                        TCustomSqlStatement sql = sqlparser.SqlStatements[i];
                        printTableTokensInStmt(sql, 0);
    
                        for (int j = 0; j < sql.ChildNodes.Count(); j++) {
                            if (sql.ChildNodes[j] is TCustomSqlStatement) {
                                tablesInStmt(sql.ChildNodes[j] as TCustomSqlStatement, 0);
                            }
                        }
    
                    }
    
                    if (bSortColumn) {
                        //Console.WriteLine(System.Environment.NewLine + "print columns in the same order they appear in sql statement");
                        columnInfos.Sort(delegate(columnInfo a, columnInfo b) {
                            int xdiff = a.column.XPosition - b.column.XPosition;
                            if (xdiff != 0) return xdiff;
                            return a.column.YPosition - b.column.YPosition;
                        });
    
                        printColumnInfos();
                    }
    
    
    
                }
    
                static void printColumnInfos() {
    
                    int columnOrder = 1;
                    //Console.WriteLine("{0,-15}{1,-25}{2,-25}{3,-15}\n{4,-20}{5,-20}{6,-40}", "pos", "column", "table", "t-alias", "schema", "DB","Loc");
                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", "columnOrder", "location", "ColumnName", "TableName", "TableAlias", "Schema", "DatabaseName", "Notes");
                    foreach(columnInfo c in columnInfos) {
    
                        TSourceToken st = c.column;
                        String notes = "";
    
                        if (st.Location == TLzOwnerLocation.elWhere) {
                            notes = whereclause(c.table.stmt, st);
                        } else if (st.Location == TLzOwnerLocation.elHaving) {
                            notes = havingclause((TSelectSqlStatement) c.table.stmt, st);
                        } else if (st.Location == TLzOwnerLocation.eljoinitemcondition) {
                            notes = joincondition((TSelectSqlStatement) c.table.stmt, st);
                        }
    
                        //  Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", String.Format("[{0,3},{1,3}]", c.column.XPosition, c.column.YPosition), c.column.AsText, c.table.getTableName(), c.table.getTableAliasName(), c.table.getSchemaName(), c.table.getDatabaseName(), getTokenLocation(c.column).Trim());
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", columnOrder, getTokenLocation(c.column), c.column.AsText, c.table.getTableName(), c.table.getTableAliasName(), c.table.getSchemaName(), c.table.getDatabaseName(), notes);
                        columnOrder++;
                    }
                }
    
                static void tablesInStmt(TCustomSqlStatement stmt, int level) {
    
                    printTableTokensInStmt(stmt, level);
    
                    for (int j = 0; j < stmt.ChildNodes.Count(); j++) {
                        if (stmt.ChildNodes[j] is TCustomSqlStatement) {
                            tablesInStmt(stmt.ChildNodes[j] as TCustomSqlStatement, level + 1);
                        }
                    }
    
                }
    
                static void printTableTokensInStmt(TCustomSqlStatement stmt, int level) {
                    tableInfo tableInfo = new tableInfo(stmt);
    
                    TSourceTokenList tokenList = stmt.TableTokens;
                    if (!bSortColumn) {
                        String typeinfo = stmt.SqlStatementType.ToString();
                        if (stmt is TLzPlsql_Package) {
                            TLzPlsql_Package package = (TLzPlsql_Package) stmt;
                            typeinfo += '(' + package._package_name.AsText + ')';
                        } else if (stmt is TLzPlsql_SubProgram) {
                            TLzPlsql_SubProgram procedure = (TLzPlsql_SubProgram) stmt;
                            typeinfo += '(' + procedure._procedure_name.AsText + ')';
                        } else if (stmt is TLzPlsql_Trigger) {
                            TLzPlsql_Trigger trigger = (TLzPlsql_Trigger) stmt;
                            typeinfo += '(' + trigger._ndTriggername.AsText + ')';
                        }
                        Console.WriteLine(new String(' ', level) + "tables in {0}: {1}  adfafsasfa", typeinfo, tokenList.Count());
    
                    }
    
    
    
                    TSourceToken st = null;
                    string tablestr = null;
                    string tablealias = null;
    
                    for (int i = 0; i < tokenList.Count(); i++) {
                        st = tokenList[i];
                        tableInfo.table = st;
                        tablestr = st.AsText;
                        if (st.RelatedToken != null) {
                            tablealias = "alias: " + st.RelatedToken.AsText;
                            tableInfo.tableAlias = st.RelatedToken;
                        }
                        if (st.ParentToken != null) {
                            //schema
                            tablestr = st.ParentToken.AsText + "." + tablestr;
                            tableInfo.schema = st.ParentToken;
    
                            if (st.ParentToken.ParentToken != null) {
                                //database
                                tablestr = st.ParentToken.ParentToken.AsText + "." + tablestr;
                                tableInfo.database = st.ParentToken.ParentToken;
                            }
                        }
                        if (!bSortColumn) {
                            TableNames.Add(tablestr);
                            Console.WriteLine(new String(' ', level + 1) + "TABLE NAME" + tablestr + getTokenPosition(st) + " " + tablealias);
                        }
                        printColumnsInTableToken(stmt, st, level + 2, tableInfo);
                    }
                }
    
                static void printColumnsInTableToken(TCustomSqlStatement stmt, TSourceToken st, int level, tableInfo tableInfo) {
    
                    if (st.RelatedToken != null) {
                        // declared table alias token
                        TSourceToken rt = st.RelatedToken;
                        TSourceToken rrt = null;
                        for (int i = 0; i < rt.RelatedTokens.Count(); i++) {
                            rrt = rt.RelatedTokens[i];
                            if (rrt.ChildToken != null) {
                                columnInfo columnInfo = new columnInfo(tableInfo);
                                columnInfo.column = rrt.ChildToken;
                                columnInfos.Add(columnInfo);
    
                                if (!bSortColumn) {
                                    ColumnNames.Add(rrt.ChildToken.AsText);
                                    Console.WriteLine(new String(' ', level + 1) + "IDHAR HU" + rrt.ChildToken.AsText + getTokenPosition(rrt.ChildToken) + "," + getTokenLocation(rrt.ChildToken));
                                }
                            }
                        }
                    }
    
                    TSourceToken rtt = null;
                    for (int i = 0; i < st.RelatedTokens.Count(); i++) {
                        // reference table token
                        rtt = st.RelatedTokens[i];
                        if (rtt.DBObjType == TDBObjType.ttObjField) {
                            // get all field tokens link with table token (those token not linked by syntax like tablename.fieldname)
                            // but like this : select f from t
    
                            columnInfo columnInfo = new columnInfo(tableInfo);
                            columnInfo.column = rtt;
                            columnInfos.Add(columnInfo);
    
                            if (!bSortColumn)
                                Console.WriteLine(new String(' ', level + 1) + rtt.AsText + getTokenPosition(rtt) + getColumnTokenIsDetermined(rtt) + "," + getTokenLocation(rtt));
                        }
                        if (rtt.ChildToken != null) {
                            columnInfo columnInfo = new columnInfo(tableInfo);
                            columnInfo.column = rtt.ChildToken;
                            columnInfos.Add(columnInfo);
    
                            if (!bSortColumn)
                                Console.WriteLine(new String(' ', level + 1) + rtt.ChildToken.AsText + getTokenPosition(rtt.ChildToken) + getColumnTokenIsDetermined(rtt.ChildToken) + "," + getTokenLocation(rtt.ChildToken));
                        }
                    }
                }
    
                static string getColumnTokenIsDetermined(TSourceToken st) {
                    if ((st.DBObjType == TDBObjType.ttObjField)) {
                        return " <guessed> ";
                    } else {
                        return "";
                    }
                }
                static string getTokenPosition(TSourceToken st) {
                    return "(" + st.XPosition + "," + st.YPosition + ")";
                }
    
                static string getTokenLocation(TSourceToken st) {
                    if ((st.Location == TLzOwnerLocation.elfieldbyattr) || (st.Location == TLzOwnerLocation.elfieldbyexpr)) {
                        return "columnResult/select list";
                    } else if (st.Location == TLzOwnerLocation.elWhere) {
                        return "where clause";
                    } else if (st.Location == TLzOwnerLocation.elHaving) {
                        return "having clause";
                    } else if (st.Location == TLzOwnerLocation.elgroupby) {
                        return "group by clause";
                    } else if (st.Location == TLzOwnerLocation.elorderby) {
                        return "order by clause";
                    } else if (st.Location == TLzOwnerLocation.eltableFuncArg) {
                        return "from clause";
                    } else if (st.Location == TLzOwnerLocation.eljoinitemcondition) {
                        return "join condition";
                    } else {
                        return st.Location.ToString();
                    }
    
                }
    
                static string whereclause(TCustomSqlStatement stmt, TSourceToken st) {
                    string ret = "";
                    if (stmt.WhereClause == null) {
                        return ret;
                    }
    
                    ret = stmt.WhereClause.AsText;
    
                    return ret;
                }
    
                static string havingclause(TSelectSqlStatement stmt, TSourceToken st) {
                    string ret = "";
                    if (stmt.HavingClause == null) {
                        return ret;
                    }
    
                    ret = stmt.HavingClause.AsText;
    
                    return ret;
                }
    
                static string joincondition(TSelectSqlStatement stmt, TSourceToken st) {
                    string ret = "";
                    if (stmt.JoinTables.Count() == 0) {
                        return ret;
                    }
    
                    TLzJoin join = stmt.JoinTables[0];
                    if (join.JoinItems.Count() == 0) {
                        return ret;
                    }
    
                    foreach(TLzJoinItem joinitem in join.JoinItems) {
                        for (int k = joinitem.JoinQual.StartToken.posinlist; k <= joinitem.JoinQual.EndToken.posinlist; k++) {
                            if (st.posinlist == k) {
                                ret = joinitem.JoinQual.AsText;
                                break;
                            }
                        }
                    }
    
    
                    return ret;
                }
    
    
            }
    
        }
    }
    
