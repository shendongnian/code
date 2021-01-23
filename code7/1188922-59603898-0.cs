    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using Microsoft.Extensions.Options;
    using Tsl.CustomPrice.Interfaces;
    using Tsl.CustomPrice.Model;
    using Tsl.CustomPrice.Model.Configuration;
    using Tsl.CustomPrice.Model.Tso;
    using Tsl.Shared.Enumeration;
    
    namespace Tsl.CustomPrice.Data
    {
        public class TsoContext : ITsoContext
        {
            private readonly string _connectionString;
            private IDbConnection Connection => new SqlConnection(_connectionString);
    
            public TsoContext(IOptions<DbSettings> settings)
            {
                _connectionString = settings.Value.ConnectionStrings.TsoConnection;
            }
    
            #region Custom Price Column
    
            public int GetCustomPriceRulesCountForUser(int userId)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"SELECT count(*)
                                    FROM [TSO].[dbo].[CustomPriceColumn] a (NOLOCK)
                                    INNER JOIN [TSO].[dbo].[CustomPriceRule] b (NOLOCK) on b.CustomPriceColumnID = a.CustomPriceColumnID
                                    WHERE [EntityID] = @userId and [EntityTypeID] = 1 --User";
    
                    return conn.ExecuteScalar<int>(query, new { userId });
                }
            }
    
            public int GetCustomPriceColumnCountForUser(int userId)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"SELECT count(*)
                                FROM [TSO].[dbo].[CustomPriceColumn] (NOLOCK)
    	                        WHERE [EntityID] = @userId and [EntityTypeID] = 1 --User";
    
                    return conn.ExecuteScalar<int>(query, new { userId });
                }
            }
    
            public CustomPriceColumnModel GetLastUpdatedCustomPriceColumn(int userId)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"SELECT [CustomPriceColumnID]
                                  ,[EntityID]
                              FROM [TSO].[dbo].[CustomPriceColumn] (NOLOCK)
    	                        WHERE [EntityID] = @userId and [EntityTypeID] = 1 --User
    	                        ORDER BY [LastUpdatedDateTime] desc";
    
                    return conn.Query<CustomPriceColumnModel>(query, new { userId }).FirstOrDefault();
                }
            }
    
            public CustomPriceColumnModel GetCustomPriceColumn(int customPriceColumnId, int userId)
            {
                using (IDbConnection conn = Connection)
                {
                    const string query = @"SELECT [CustomPriceColumnID]
                              ,[EntityID]
                              ,[EntityTypeID]
                              ,[CustomPriceColumnTypeID]
                              ,a.[CreatedDateTime]
                              ,case when (CreatedByUserID = @userId or CustomPriceColumnTypeID = 2) then 1 else 0 end as IsEditable
    						  ,b.FirstName as CreatedByFirstName
    						  ,b.LastName as CreatedByLastName
                          FROM [dbo].[CustomPriceColumn] a (nolock)
    					  left join [User] b on b.UserID = a.CreatedByUserID
                          WHERE [CustomPriceColumnID] = @customPriceColumnId";
    
                    return conn.QueryFirstOrDefault<CustomPriceColumnModel>(query, new { @customPriceColumnId=customPriceColumnId, @userId=userId });
                }
            }
            public IEnumerable<CustomPriceColumnModel> GetCustomPriceColumns(int userId)
            {
                using (IDbConnection conn = Connection)
                {
                    const string query = @"SELECT
    	                          [CustomPriceColumnID]
                                  ,[EntityID]
                                  ,[EntityTypeID]
                                  ,case when (CreatedByUserID = @userId or CustomPriceColumnTypeID = 2) then 1 else 0 end as IsEditable
    							  ,b.FirstName as CreatedByFirstName
    							  ,b.LastName as CreatedByLastName
    	                        FROM CustomPriceColumn cpc (nolock)
    		                        inner join [User] u (nolock)
    			                        on u.UserID = @userId
    								left join [User] b on b.UserID = CreatedByUserID
    	                        WHERE (EntityID = @userId and EntityTypeID = 1)
    		                        or (CreatedByUserID = @userId)
    		                        or (EntityID = u.CompanyID and EntityTypeID = 0)";
    
                    return conn.Query<CustomPriceColumnModel>(query, new { userId });
                }
            }
    
    
            public int CreateCustomPriceColumn(string customPriceColumnName, string customPriceColumnDescription, int entityId, int createdByUserId, string countryCode, IndustryTypes industryTypeId, EntityTypes entityTypeId, CustomPriceColumnTypes customPriceColumnTypeId, string systemUserName, string actorName)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"INSERT INTO [TSO].[dbo].[CustomPriceColumn]
                                           ([EntityID]
                                           ,[EntityTypeID]
                                           ,[CustomPriceColumnTypeID]
                                           ,[CreatedByUserID]
                                           ,[IndustryTypeID]
                                           ,[CountryCode]
                                           ,[CustomPriceColumnName]
                                           ,[CustomPriceColumnDescription]
                                           ,[CreatedDateTime]
                                           ,[LastUpdatedDateTime]
                                           ,[ActorName]
                                           ,[SystemUserName])
                                     VALUES
                                           (@entityId
                                           ,@entityTypeId
                                           ,@customPriceColumnTypeId
                                           ,@createdByUserId
                                           ,@industryTypeId
                                           ,@countryCode
                                           ,@customPriceColumnName
                                           ,@customPriceColumnDescription
                                           ,getdate()
                                           ,getdate()
                                           ,@actorName
                                           ,@systemUserName);
                                        SELECT CAST(SCOPE_IDENTITY() as int)";
    
    
                    return conn.ExecuteScalar<int>(query,
                        new
                        {
                            entityId,
                            entityTypeId,
                            customPriceColumnTypeId,
                            createdByUserId,
                            industryTypeId,
                            countryCode,
                            customPriceColumnName,
                            customPriceColumnDescription,
                            actorName,
                            systemUserName
                        });
    
                }
            }
    
            public void UpdateCustomPriceColumn(int customPriceColumnId, string customPriceColumnName, string customPriceColumnDescription, int entityId, IndustryTypes industryTypeId, EntityTypes entityTypeId, CustomPriceColumnTypes customPriceColumnTypeId, string systemUserName, string actorName)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"UPDATE [TSO].[dbo].[CustomPriceColumn]
                               SET [EntityID] = @entityId
                                  ,[EntityTypeID] = @entityTypeId
                                  ,[CustomPriceColumnTypeID] = @customPriceColumnTypeId
                                  ,[IndustryTypeID] = @industryTypeId
                                  ,[CustomPriceColumnName] = @customPriceColumnName
                                  ,[CustomPriceColumnDescription] = @customPriceColumnDescription
                                  ,[LastUpdatedDateTime] = getdate()
                             WHERE [CustomPriceColumnID] = @customPriceColumnId";
    
    
                    conn.Execute(query,
                        new
                        {
                            customPriceColumnId,
                            entityId,
                            entityTypeId,
                            customPriceColumnTypeId,
                            industryTypeId,
                            customPriceColumnName,
                            customPriceColumnDescription,
                            actorName,
                            systemUserName
                        });
    
                }
            }
    
            public void DeleteCustomPriceColumn(int customPriceColumnId)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"DELETE FROM [TSO].[dbo].[CustomPriceColumn]
                                 WHERE [CustomPriceColumnID] = @customPriceColumnId";
    
    
                    conn.Execute(query,
                        new
                        {
                            customPriceColumnId
                        });
    
                }
            }
    
            public CustomPriceColumnMetaDataForCpfExportEntity GetCustomPriceColumnMetaDataForCpfExport(int customPriceColumnId)
            {
                var ret = new CustomPriceColumnMetaDataForCpfExportEntity();
                using (IDbConnection conn = Connection)
                {
                    const string query = @"
                        -- TOTAL RULES VS. TOTAL PERCENT RULES
                        SELECT tr.TotalRules, trp.TotalPercentRules FROM
                        (SELECT CustomPriceColumnId, COUNT(*) AS TotalRules FROM tso.dbo.CustomPriceRule WHERE CustomPriceColumnID = @CustomPriceColumnId GROUP BY CustomPriceColumnID) as tr
                        JOIN
                        (SELECT CustomPriceColumnId, COUNT(*) AS TotalPercentRules FROM tso.dbo.CustomPriceRule WHERE CustomPriceColumnID = @CustomPriceColumnId AND IsPercent = 1 GROUP BY CustomPriceColumnID) AS trp
                        ON tr.CustomPriceColumnID = trp.CustomPriceColumnID;
                        -- TOTAL RULES BY BASE COLUMN
                        SELECT BaseColumnPriceTypeID, OperationTypeId, COUNT(*) AS TotalRules FROM tso.dbo.CustomPriceRule WHERE CustomPriceColumnID = @CustomPriceColumnId
                        GROUP BY BaseColumnPriceTypeID, OperationTypeId";
    
                    using (SqlMapper.GridReader multi = conn.QueryMultiple(query, new { @customPriceColumnId = customPriceColumnId }))
                    {
                        ret.MetaData = multi.Read<CustomPriceColumnMetaDataEntity>().SingleOrDefault();
                        ret.BasePriceColumnRuleCounts = multi.Read<BasePriceColumnRuleCountEntity>().ToList();
                    }
    
                    return ret;
                }
            }
            #endregion
    
            #region Custom Price Rule
    
            public IEnumerable<int> GetCustomPriceRulesIds(int customPriceColumnId)
            {
    
                using (IDbConnection conn = Connection)
                {
                    var query =
                        @"SELECT [CustomPriceRuleId] FROM [dbo].[CustomPriceRule] (nolock) WHERE [CustomPriceColumnId] = @customPriceColumnId";
    
                    return conn.Query<int>(query, new {customPriceColumnId});
                }
    
            }
    
            public IEnumerable<CustomPriceRuleModel> GetCustomPriceRules(int customPriceColumnId, int index, int pageSize)
            {
                //implementation can be extended to allow sorting by other 
                var sortBy = "a.CreatedDateTime desc";
    
                using (IDbConnection conn = Connection)
                {
                    var query = @"SELECT  *
                                FROM     
                                    (SELECT ROW_NUMBER() OVER ( ORDER BY {0}) AS RowNum,  
                                        COUNT(*) OVER () AS TotalRows, 
                                        [CustomPriceRuleId] 
                                        FROM [dbo].[CustomPriceRule] a (nolock) 
                                            left outer join [dbo].[Commodity] b (nolock) on a.CommodityId = b.CommodityID 
                                            left outer join [dbo].[Company] c (nolock) on a.ManufacturerCompanyId = c.CompanyId 
                                            left outer join [dbo].[Item] d (nolock) on a.ItemId = d.ItemID 
                                        WHERE [CustomPriceColumnId] = @customPriceColumnId 
                                      ) AS result 
                                WHERE RowNum BETWEEN ( ((@index - 1) * @pageSize )+ 1) AND @index*@pageSize 
                                            ORDER BY RowNum";
    
                    query = string.Format(query, sortBy);
    
                    return conn.Query<CustomPriceRuleModel>(query, new { customPriceColumnId, index, pageSize });
                }
            }
    
            public CustomPriceRuleModel GetCustomPriceRule(int customPriceRuleId)
            {
                using (IDbConnection conn = Connection)
                {
                    const string query = @"SELECT [CustomPriceRuleId]
                                          ,[CustomPriceColumnId]
                                      FROM [TSO].[dbo].[CustomPriceRule]
                                      WHERE [CustomPriceRuleId] = @customPriceRuleId";
    
                    return conn.QueryFirstOrDefault<CustomPriceRuleModel>(query, new { customPriceRuleId });
                }
            }
    
            public CustomPriceRuleModel GetCustomPriceRuleByItemId(int customPriceColumnId, int itemId)
            {
                using (IDbConnection conn = Connection)
                {
                    const string query = @"SELECT [CustomPriceRuleId]
                                          ,[CustomPriceColumnId]
                                          ,[CustomPriceRuleLevelId]
                                      FROM [TSO].[dbo].[CustomPriceRule]
                                      WHERE [CustomPriceColumnId] = @customPriceColumnId and [ItemId] = @itemId";
    
                    return conn.QueryFirstOrDefault<CustomPriceRuleModel>(query, new { customPriceColumnId, itemId });
                }
            }
    
            public CustomPriceRuleModel FindCustomPriceRule(int customPriceColumnId, CustomPriceRuleLevels customPriceRuleLevel,
                    int? itemId, int? manufacturerCompanyId, int? commodityId, string ucc)
            {
                using (IDbConnection conn = Connection)
                {
                    string query = @"SELECT [CustomPriceRuleId]
                                          ,[CustomPriceColumnId]
                                          ,[UCC]
                                      FROM [TSO].[dbo].[CustomPriceRule]
                                      WHERE [CustomPriceColumnId] = @customPriceColumnId
                                      AND [CustomPriceRuleLevelId] = @customPriceRuleLevel";
                    var parameters = new DynamicParameters();
                    parameters.Add("@customPriceColumnId", customPriceColumnId);
                    parameters.Add("@customPriceRuleLevel", (int)customPriceRuleLevel);
    
                    switch (customPriceRuleLevel)
                    {
                        case (CustomPriceRuleLevels.Item):
                            query += @" AND ItemId = @itemId";
                            parameters.Add("@itemId", itemId);
                            break;
                        case (CustomPriceRuleLevels.ManufacturerAndCommodity):
                            query += @" AND ManufacturerCompanyID = @manufacturerCompanyId
                                AND CommodityId = @commodityId";
                            parameters.Add("@manufacturerCompanyId", manufacturerCompanyId);
                            parameters.Add("@commodityId", commodityId);
                           break;
                        case (CustomPriceRuleLevels.Manufacturer):
                            query += @" AND ManufacturerCompanyID = @manufacturerCompanyId";
                            parameters.Add("@manufacturerCompanyId", manufacturerCompanyId);
                            break;
                        case (CustomPriceRuleLevels.Commodity):
                            query += @" AND CommodityId = @commodityId";
                            parameters.Add("@commodityId", commodityId);
                            break;
                        case (CustomPriceRuleLevels.Ucc):
                            query += @" AND ManufacturerCompanyID = @manufacturerCompanyId
                                AND Ucc = @ucc";
                            parameters.Add("@manufacturerCompanyId", manufacturerCompanyId);
                            parameters.Add("@ucc", ucc);
                            break;
                    }
    
                    return conn.QueryFirstOrDefault<CustomPriceRuleModel>(query, parameters);
                }
            }
    
            public void UpdateCustomPriceRule(int customPriceRuleId, CustomPriceRuleLevels customPriceRuleLevel, int? itemId, int? manufactuerCompanyId,
                int? commodityId, PriceTypes? baseColumnPriceTypeId, CustomPriceOperations? operationTypeId, decimal customPriceRuleValue, bool isPercent, string customPriceRuleDescription,
                Uom? fixedPriceUnitIfMeasureTypeCode, string ucc, string actorName, string systemUsername)
            {
    
                using (IDbConnection conn = Connection)
                {
                    var query = @"UPDATE [TSO].[dbo].[CustomPriceRule]
                                   SET [CustomPriceRuleLevelId] = @customPriceRuleLevel
                                      ,[ItemId] = @itemId
                                      ,[ManufacturerCompanyId] = @manufactuerCompanyId
                                      ,[CommodityId] = @commodityId
                                      ,[BaseColumnPriceTypeId] = @baseColumnPriceTypeId
                                      ,[OperationTypeId] = @operationTypeId
                                      ,[CustomPriceRuleValue] = @customPriceRuleValue
                                      ,[IsPercent] = @isPercent
                                      ,[CustomPriceRuleDescription] = @customPriceRuleDescription
                                      ,[FixedPriceUnitOfMeasureTypeCode] = @strUom
                                      ,[LastUpdatedDateTime] = getdate()
                                      ,[ActorName] = @actorName
                                      ,[SystemUsername] = @systemUsername
                                      ,[UCC] = @ucc
                                 WHERE [CustomPriceRuleId] = @customPriceRuleId";
    
                    var strUom = fixedPriceUnitIfMeasureTypeCode != null ? fixedPriceUnitIfMeasureTypeCode.ToString() : null;
                    // HACK: See TSL-1235 : CustomPriceOperations.FixedPrice must translate to a null in the CustomPriceRule row.
                    CustomPriceOperations? opTypeId = operationTypeId == CustomPriceOperations.FixedPrice ? null : operationTypeId;
    
                    conn.Execute(query,
                        new
                        {
                            customPriceRuleId,
                            customPriceRuleLevel,
                            itemId,
                            manufactuerCompanyId,
                            commodityId,
                            baseColumnPriceTypeId,
                            operationTypeId = opTypeId,
                            customPriceRuleValue,
                            isPercent,
                            customPriceRuleDescription,
                            strUom,
                            ucc,
                            actorName,
                            systemUsername
                        });
    
                }
            }
    
   
            public int CreateCustomPriceRule(int customPriceColumnId, CustomPriceRuleLevels customPriceRuleLevel, int? itemId,
            int? manufactuerCompanyId, int? commodityId, PriceTypes? baseColumnPriceTypeId, CustomPriceOperations? operationTypeId,
            decimal customPriceRuleValue, bool isPercent, string customPriceRuleDescription, Uom? fixedPriceUnitIfMeasureTypeCode,
            string ucc, string actorName, string systemUsername)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"INSERT INTO [TSO].[dbo].[CustomPriceRule]
                                   ([CustomPriceColumnId]
                                   ,[CustomPriceRuleLevelId]
                                   ,[ItemId]
                                   ,[ManufacturerCompanyId]
                                   ,[CommodityId]
                                   ,[BaseColumnPriceTypeId]
                                   ,[OperationTypeId]
                                   ,[CustomPriceRuleValue]
                                   ,[IsPercent]
                                   ,[CustomPriceRuleDescription]
                                   ,[FixedPriceUnitOfMeasureTypeCode]
                                   ,[CreatedDateTime]
                                   ,[LastUpdatedDateTime]
                                   ,[ActorName]
                                   ,[SystemUsername]
                                   ,[UCC])
                             VALUES
                                   (@customPriceColumnId
                                   ,@customPriceRuleLevel
                                   ,@itemId
                                   ,@manufactuerCompanyId
                                   ,@commodityId
                                   ,@baseColumnPriceTypeId
                                   ,@operationTypeId
                                   ,@customPriceRuleValue
                                   ,@isPercent
                                   ,@customPriceRuleDescription
                                   ,@strUom
                                   ,getdate()
                                   ,getdate()
                                   ,@actorName
                                   ,@systemUsername
                                   ,@ucc);
                                        SELECT CAST(SCOPE_IDENTITY() as int)";
    
                    var strUom = fixedPriceUnitIfMeasureTypeCode != null ? fixedPriceUnitIfMeasureTypeCode.ToString() : null;
    
                    return conn.ExecuteScalar<int>(query,
                        new
                        {
                            customPriceColumnId,
                            customPriceRuleLevel,
                            itemId,
                            manufactuerCompanyId,
                            commodityId,
                            baseColumnPriceTypeId,
                            operationTypeId,
                            customPriceRuleValue,
                            isPercent,
                            customPriceRuleDescription,
                            strUom,
                            ucc,
                            actorName,
                            systemUsername
                        });
    
                }
            }
    
            public void DeleteCustomPriceRule(int customPriceRuleId)
            {
                using (IDbConnection conn = Connection)
                {
                    var query = @"DELETE FROM [TSO].[dbo].[CustomPriceRule]
                                 WHERE [CustomPriceRuleId] = @customPriceRuleId";
    
    
                    conn.Execute(query,
                        new
                        {
                            customPriceRuleId
                        });
    
                }
            }
    
            public void DeleteCustomPriceRules(IEnumerable<int> customPriceRuleIds)
            {
                var cprIdsList = customPriceRuleIds.ToList();
    
                if (!cprIdsList.Any()) return;
    
                using (IDbConnection conn = Connection)
                {
                    var query = @"DELETE FROM [TSO].[dbo].[CustomPriceRule]
                                 WHERE [CustomPriceRuleId] in ("
                                + string.Join(",", cprIdsList)
                                + ")";
    
    
                    conn.Execute(query);
    
                }
            }
    
            public List<CustomPriceRuleForExportEntity> GetCustomPriceRulesForExport(int customPriceColumnId)
            {
                using (IDbConnection conn = Connection)
                {
                    const string query = @"SELECT 
                        cpr.CustomPriceRuleLevelID
                        ,cpr.Ucc
                        ,i.Upc
                        ,c.CommodityCode
                        ,mu.ShortName as ManufacturerShortName
                        ,i.ManufacturerCatalogCode
                        ,cpr.CustomPriceRuleDescription
                        ,cpr.BaseColumnPriceTypeId
                        ,cpr.OperationTypeId
                        ,cpr.CustomPriceRuleValue
                        ,cpr.IsPercent
                        ,cpr.ItemId
                        ,cpr.ManufacturerCompanyId
                        ,cpr.CommodityId
                        FROM TSO.dbo.CustomPriceRule cpr
                        LEFT OUTER JOIN TSO.dbo.Item i ON cpr.ItemId = i.ItemId
                        LEFT OUTER JOIN TSO.dbo.ManufacturerUcc mu
                            ON ((cpr.CustomPriceRuleLevelId <> 1 AND cpr.ManufacturerCompanyId = mu.CompanyID AND cpr.UCC = mu.UCC)
                            OR (cpr.CustomPriceRuleLevelId = 1 AND LEFT(i.UPC, 6) = mu.UCC) and i.ManufacturerCompanyID = mu.CompanyID)
                        LEFT OUTER JOIN TSO.dbo.Commodity c ON cpr.CommodityId = c.CommodityId
                        WHERE cpr.CustomPriceColumnId = @customPriceColumnId";
    
                    return conn.Query<CustomPriceRuleForExportEntity>(query, new { @customPriceColumnId = customPriceColumnId }).ToList();
                }
            }
    
            #endregion
    
            public bool IsAllowedToModifyCustomPriceColumn(int userId, int customPriceColumnId)
            {
                using (IDbConnection conn = Connection)
                {
                    // Check access to CP colummn.
                    var getCpQuery = @"SELECT [CustomPriceColumnID]
                        ,[EntityID]
                        ,[EntityTypeID]
                        ,[CustomPriceColumnTypeID]
                        ,[CreatedByUserID]
                        ,[IndustryTypeID]
                        ,[CountryCode]
                        ,[CustomPriceColumnName]
                        ,[CustomPriceColumnDescription]
                        ,cpc.[CreatedDateTime]
                        ,cpc.[LastUpdatedDateTime]
                    FROM [CustomPriceColumn] cpc
                    JOIN [User] u ON u.UserId = @userId
                    WHERE cpc.[CustomPriceColumnId] = @customPriceColumnId
                    AND ((cpc.[CreatedByUserID] = @userId) /* Created by the User */
                    OR (cpc.EntityID = u.CompanyId and cpc.EntityTypeID = 0 AND CustomPriceColumnTypeID = 2)) /* OR CREATED BY SOMEONE IN THE COMPANY AND MARKED PUBLIC-EDITABLE */"; 
                    return conn.Query<CustomPriceColumnModel>(getCpQuery, new { @customPriceColumnId = customPriceColumnId, @userId = userId }).SingleOrDefault() != null;
    
                }
            }
    
            /// <summary>
            /// DTO for UserProfileProperty
            /// </summary>
            private class UserProfilePropertyDto
            {
                public string Value { get; set; }
            }
        }
    }
