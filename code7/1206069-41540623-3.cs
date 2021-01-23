    [WebMethod(Description = "Get Query Builder Filter Option")]
        public QueryBuilderSettings GetQueryBuilderFilterOption()
        {
            string QBID;
            string QBLabel;
            string propertyInputType;
            QueryBuilderDataType QBDataType;
            List<QueryBuilderFilterOperators> QBFilterOperators;
    		string propertyType;
            QueryBuilderInputType QBInputType;
            //List<object> dropdownValues = new List<object>();
            Dictionary<string, string> dropdownValues = new Dictionary<string, string>();
    
            QueryBuilderSettings settings = new QueryBuilderSettings();
    
            List<string> PropertyNames = GetPropertyList(); 
    
            foreach(string propertyName in PropertyNames)
            {
                QBID = propertyName;
                QBLabel = PropertyTitle[propertyName];
                propertyInputType = GetPropertyInputType(propertyName);
                QBDataType = QueryBuilderFilter.GetQueryBuilderDataType(propertyInputType);
                propertyType = GetPropertyType(propertyName);
                QBInputType = QueryBuilderFilter.GetQueryBuilderInputType(propertyType);
                QBFilterOperators = QueryBuilderFilter.GetQueryBuilderFilterOperator(QBInputType);
    
    			dropdownValues = GetDropdownDictionary(propertyName);
    
                settings.filters.Add(new QueryBuilderFilter(QBID, QBLabel, QBDataType, QBFilterOperators, QBInputType, dropdownValues));
                //dropdownValues =  new List<object>();
                dropdownValues =  new Dictionary<string, string>(); //Clear the Dictionary or it will add up all dropdown from different properties
            }
    		
            return settings;
        }
