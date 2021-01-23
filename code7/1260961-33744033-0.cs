    public IQueryable<DiagTab> Clooper(string m_ValEnvoi)
        {
            string Ladatatable = m_ValEnvoi; 
    
          
                var secki = db.DiagTabs.Where(Ladatatable); // Ladatatabase = Dynamic LinQ 
    
                return secki;
       }
