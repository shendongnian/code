    namespace Dapper
    {
        #region NameSpaces
    
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.Linq;
    
        #endregion
    
       
            /// <summary>
            ///     Type Map class for database provider specific code
            /// </summary>
            internal abstract class TypeMap
            {
                /// <summary>
                /// Only Non Input Parameters collection
                /// </summary>
                public abstract Dictionary<string, object> NonInputParameterCollection { get; set; } 
    
                /// <summary>
                /// Method to execute the DML via TypeMap
                /// </summary>
                /// <param name="connection"></param>
                /// <param name="sql"></param>
                /// <param name="commandType"></param>
                /// <param name="dapperParams"></param>
                /// <returns></returns>
                public abstract int Execute(IDbConnection connection, 
                                            string sql, 
                                            CommandType commandType,
                                            IEnumerable<DapperParam> dapperParams );
    
                /// <summary>
                /// Method to execute the Select to fetch IEnumerable via TypeMap
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="connection"></param>
                /// <param name="sql"></param>
                /// <param name="commandType"></param>
                /// <param name="dapperParams"></param>
                /// <returns></returns>
                public abstract IEnumerable<T> Query<T>(IDbConnection connection,
                                                        string sql,
                                                        CommandType commandType,
                                                        IEnumerable<DapperParam> dapperParams) where T : new();
    
                /// <summary>
                /// Fetch the relevant TypeMap
                /// </summary>
                /// <param name="provider"></param>
                /// <returns></returns>
                public static TypeMap GetTypeMap(string provider)
                {
                    TypeMap typeMap = null;
    
                    switch (provider)
                    {
                        case "System.Data.SqlClient":
                            typeMap = new SqlTypeMap();
                            break;
                        default:
                            // SQl Server TypeMap
                            typeMap = new SqlTypeMap();
                            break;
                    }
    
                    return (typeMap);
                }
            }
    
            /// <summary>
            ///     SQL Server provider type map
            /// </summary>
            internal class SqlTypeMap : TypeMap
            {
                public SqlTypeMap()
                {
                    NonInputParameterCollection = new Dictionary<string, object>();
                }
    
                public override sealed Dictionary<string, object> NonInputParameterCollection { get; set; } 
    
                public override int Execute(IDbConnection connection,
                                            string sql,
                                            CommandType commandType,
                                            IEnumerable<DapperParam> dapperParams)
                {
                    int returnValue = -1;
    
                    var sqlConnection = (connection as SqlConnection) ?? new SqlConnection();
    
                    using (sqlConnection)
                    {
                        SqlCommand sqlCommand = null;
    
                        sqlCommand = sqlConnection.CreateCommand();
                        
                        using (sqlCommand)
                        {
                            // public SqlParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, bool sourceColumnNullMapping, object value, string xmlSchemaCollectionDatabase, string xmlSchemaCollectionOwningSchema, string xmlSchemaCollectionName);
                            foreach (var param in dapperParams)
                            {
                                sqlCommand.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = param.ParamName,
                                    SqlValue = param.ParamValue ?? DBNull.Value,
                                    SqlDbType = TypeToSqlDbType[param.ParamType],
                                    Direction = Map.DirectionMap[param.ParamDirection]
                                });
                            }
    
                            sqlCommand.CommandText = sql; // Assign Sql Text
                            sqlCommand.CommandType = commandType; // Assign CommandType
                            sqlCommand.Connection.Open(); // Explicitly open connection to use it with SqlCommand object
                            returnValue = sqlCommand.ExecuteNonQuery(); // Execute Query
    
                            foreach (SqlParameter param in sqlCommand.Parameters.Cast<SqlParameter>().Where(param => param.Direction != ParameterDirection.Input))
                                NonInputParameterCollection.Add(param.ParameterName, param.Value);
                        }
                    }
    
                    return (returnValue);
                }
    
                public override IEnumerable<T> Query<T>(IDbConnection connection,
                                          string sql,
                                          CommandType commandType,
                                          IEnumerable<DapperParam> dapperParams)
                {
                    IEnumerable<T> returnEnumerable = null;
    
                    var sqlConnection = (connection as SqlConnection) ?? new SqlConnection();
    
                    using (sqlConnection)
                    {
                        var sqlCommand = sqlConnection.CreateCommand();
    
                        using (sqlCommand)
                        {
                            foreach (var param in dapperParams)
                            {
                                sqlCommand.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = param.ParamName,
                                    SqlValue = param.ParamValue ?? DBNull.Value,
                                    SqlDbType = TypeToSqlDbType[param.ParamType],
                                    Direction = Map.DirectionMap[param.ParamDirection]
                                });
                            }
    
                            sqlCommand.CommandText = sql; // Assign Sql Text
                            sqlCommand.CommandType = commandType; // Assign CommandType
    
                            var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
    
                            var returnDataTable = new DataTable();
    
                            sqlDataAdapter.Fill(returnDataTable);
    
                            returnEnumerable = Common.ToList<T>(returnDataTable);
    
                            foreach (SqlParameter param in sqlCommand.Parameters.Cast<SqlParameter>()
                                                                     .Where(param => param.Direction != ParameterDirection.Input))
                                NonInputParameterCollection.Add(param.ParameterName, param.Value);
                        }
                    }
    
                    return (returnEnumerable);
                }
    
                /// <summary>
                ///     Data Type to Db Type mapping dictionary for SQL Server
                /// https://msdn.microsoft.com/en-us/library/cc716729(v=vs.110).aspx
                /// </summary>
                
                public static readonly Dictionary<Type, SqlDbType> TypeToSqlDbType = new Dictionary<Type, SqlDbType>
                {
                  // Mapping C# types to Ado.net SqlDbType enumeration
                    {typeof (byte), SqlDbType.TinyInt},
                    {typeof (sbyte), SqlDbType.TinyInt},
                    {typeof (short), SqlDbType.SmallInt},
                    {typeof (ushort), SqlDbType.SmallInt},
                    {typeof (int), SqlDbType.Int},
                    {typeof (uint), SqlDbType.Int},
                    {typeof (long), SqlDbType.BigInt},
                    {typeof (ulong), SqlDbType.BigInt},
                    {typeof (float), SqlDbType.Float},
                    {typeof (double), SqlDbType.Float},
                    {typeof (decimal), SqlDbType.Decimal},
                    {typeof (bool), SqlDbType.Bit},
                    {typeof (string), SqlDbType.VarChar},
                    {typeof (char), SqlDbType.Char},
                    {typeof (Guid), SqlDbType.UniqueIdentifier},
                    {typeof (DateTime), SqlDbType.DateTime},
                    {typeof (DateTimeOffset), SqlDbType.DateTimeOffset},
                    {typeof (byte[]), SqlDbType.VarBinary},
                    {typeof (byte?), SqlDbType.TinyInt},
                    {typeof (sbyte?), SqlDbType.TinyInt},
                    {typeof (short?), SqlDbType.SmallInt},
                    {typeof (ushort?), SqlDbType.SmallInt},
                    {typeof (int?), SqlDbType.Int},
                    {typeof (uint?), SqlDbType.Int},
                    {typeof (long?), SqlDbType.BigInt},
                    {typeof (ulong?), SqlDbType.BigInt},
                    {typeof (float?), SqlDbType.Float},
                    {typeof (double?), SqlDbType.Float},
                    {typeof (decimal?), SqlDbType.Decimal},
                    {typeof (bool?), SqlDbType.Bit},
                    {typeof (char?), SqlDbType.Char},
                    {typeof (Guid?), SqlDbType.UniqueIdentifier},
                    {typeof (DateTime?), SqlDbType.DateTime},
                    {typeof (DateTimeOffset?), SqlDbType.DateTimeOffset},
                    {typeof (System.Data.Linq.Binary), SqlDbType.Binary},
                    {typeof (IEnumerable<>), SqlDbType.Structured},
                    {typeof (List<>), SqlDbType.Structured},
                    {typeof (DataTable), SqlDbType.Structured},
    
                };
    
               
                
            }
    
            /// <summary>
            /// 
            /// </summary>
            public static class Map
        {
            /// <summary>
            /// 
            /// </summary>
            public static Dictionary<Type, DbType> TypeToDbType = new Dictionary<Type, DbType>()
            {
                {typeof (byte), DbType.Byte},
                {typeof (sbyte), DbType.Byte},
                {typeof (short), DbType.Int16},
                {typeof (ushort), DbType.Int16},
                {typeof (int), DbType.Int32},
                {typeof (uint), DbType.Int32},
                {typeof (long), DbType.Int64},
                {typeof (ulong), DbType.Int64},
                {typeof (float), DbType.Single},
                {typeof (double), DbType.Double},
                {typeof (decimal), DbType.Decimal},
                {typeof (bool), DbType.Boolean},
                {typeof (string), DbType.String},
                {typeof (char), DbType.StringFixedLength},
                {typeof (Guid), DbType.Guid},
                {typeof (DateTime), DbType.DateTime},
                {typeof (DateTimeOffset), DbType.DateTimeOffset},
                {typeof (byte[]), DbType.Binary},
                {typeof (byte?), DbType.Byte},
                {typeof (sbyte?), DbType.Byte},
                {typeof (short?), DbType.Int16},
                {typeof (ushort?), DbType.Int16},
                {typeof (int?), DbType.Int32},
                {typeof (uint?), DbType.Int32},
                {typeof (long?), DbType.Int64},
                {typeof (ulong?), DbType.Int64},
                {typeof (float?), DbType.Single},
                {typeof (double?), DbType.Double},
                {typeof (decimal?), DbType.Decimal},
                {typeof (bool?), DbType.Boolean},
                {typeof (char?), DbType.StringFixedLength},
                {typeof (Guid?), DbType.Guid},
                {typeof (DateTime?), DbType.DateTime},
                {typeof (DateTimeOffset?), DbType.DateTimeOffset},
                {typeof (System.Data.Linq.Binary), DbType.Binary}
            };
    
            /// <summary>
            ///     Parameter Direction for Stored Procedure
            /// </summary>
            public static readonly Dictionary<string, ParameterDirection> DirectionMap =
                   new Dictionary<string, ParameterDirection>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {ParamDirectionConstants.Input, ParameterDirection.Input},
                    {ParamDirectionConstants.Output, ParameterDirection.Output},
                    {ParamDirectionConstants.InputOutput, ParameterDirection.InputOutput},
                    {ParamDirectionConstants.ReturnValue, ParameterDirection.ReturnValue}
                };
        }
    }
