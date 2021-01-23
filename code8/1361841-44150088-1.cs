         bool AddUpdateData(List<MyClass> data)
        {
            bool returnResult = false;
            string datatXml = Helper.SerializeObjectToXmlString(data);
            var sqlparam = new List<SqlParameter>()
                         {
           new SqlParameter() { ParameterName = "dataXml", Value = datatXml}
                           
                         };
            var result = this.myEntity.Repository<SQL_StoredProc_ComplexType>().ExecuteStoredProc("SQL_StoredProc", sqlparam);
            if (result != null && result.Count() > 0)
            {
                returnResult = result[0].Status == 1 ? true : false;
            }
            return returnResult;
        }
