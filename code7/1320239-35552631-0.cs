        public List<T_SysConfig> GetSysConfigs(List<int> ids)
        {
            List<T_SysConfig> sysConfigObjs = GetSysConfigs().ToList();
            List<T_SysConfig> result =(from c1 in sysConfigObjs 
                                        join c2 in ids on c1.Id equals c2
                                        select c1).ToList();
            return result;
        }
    
