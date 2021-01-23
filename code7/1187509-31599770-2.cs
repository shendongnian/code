    public  class   Entity
                    <
                        TEntity,
                        TDataObject,
                        TIBusiness,
                        TPrimaryKey
                    >
            where   TEntity     : Entity<TEntity, TDataObject, TIBusiness, TPrimaryKey>
            where   TDataObject : Entity<TEntity, TDataObject, TIBusiness, TPrimaryKey>.BaseDataObject, new()
            where   TIBusiness  : Entity<TEntity, TDataObject, TIBusiness, TPrimaryKey>.IBaseBusiness
    {
        public
        abstract    class       BaseDataObject
        {
            public  TPrimaryKey Id;
        }
        public      interface   IBaseBusiness
        {
            TDataObject GetByID(TPrimaryKey id);
        }
        
        public  class   PresentationMapper<TPresentationModel>
                where   TPresentationModel  : new()
        {
            private
            static  Dictionary
                    <
                        string, 
                        MemberInfo
                    >                   entityFieldsAndProperties       = typeof(TDataObject).GetProperties().AsEnumerable<MemberInfo>().Union(typeof(TDataObject).GetFields().AsEnumerable<MemberInfo>()).ToDictionary<MemberInfo, string>(memberInfo=>memberInfo.Name);
            private
            static  Dictionary
                    <
                        string, 
                        MemberInfo
                    >                   presentationFieldsAndProperties = typeof(TPresentationModel).GetProperties().AsEnumerable<MemberInfo>().Union(typeof(TPresentationModel).GetFields().AsEnumerable<MemberInfo>()).ToDictionary<MemberInfo, string>(memberInfo=>memberInfo.Name);
            private TIBusiness          business;
            
            public                      PresentationMapper(TIBusiness business) { this.business = business; }
        
            public  TPresentationModel  GetByID(TPrimaryKey id)
            {
                var dataObject  = this.business.GetByID(id);
                return this.map(dataObject);
            }
            private TPresentationModel  map(TDataObject dataObject)
            {
                var returnModel             = new TPresentationModel();
                var presentationMemberInfo  = (MemberInfo) null;
                foreach(string key in entityFieldsAndProperties.Keys)
                if (presentationFieldsAndProperties.TryGetValue(key, out presentationMemberInfo))
                {
                    this.copy
                    (
                        value:  this.getValue(from: dataObject, @using: entityFieldsAndProperties[key]), 
                        to:     returnModel, 
                        @using: presentationMemberInfo
                    );
                }
                return returnModel;
            }
            private object              getValue(TDataObject from, MemberInfo @using)
            {
                return @using is PropertyInfo ? ((PropertyInfo) @using).GetValue(from) : ((FieldInfo) @using).GetValue(from);
            }
            
            private void                copy(object value, TPresentationModel to, MemberInfo @using)
            {
                if (@using is PropertyInfo)     ((PropertyInfo) @using).SetValue(to, value);
                else                            ((FieldInfo) @using).SetValue(to, value);
            }
            
        }
    }
