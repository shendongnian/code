     [OperationContract]
        public List<Drug> GetAll_Drug()
        {
            List<Drug> obj_Lst_t;
            using (var ctx = new EpriscriptionContext())
            {
                ctx.Configuration.ProxyCreationEnabled = false; 
        
        foreach(var data in ctx.Drug)
               { obj_Lst_t.add(new Drug{...});}
            }
            return obj_Lst_t;
        }
