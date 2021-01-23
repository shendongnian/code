     private void applyFilter()
    {
        generateFilter(m_drawingNumberFilter);
        generateFilter(m_partNumberFilter);
    }
    private void generateFilter(string filter)
    {
      if(!string.IsNullOrEmpty(filter))
      {
       if(string.IsNullOrEmpty(m_currentFilter))
        {
          m_currentFilter=filter;
        }else
        {
           m_currentFilter+= " AND " + filter;
        }
       }
     }
    
