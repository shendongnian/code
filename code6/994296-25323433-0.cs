     DataTable m_DataTable = gvSrc.DataSource as DataTable;
    
       if (m_DataTable != null)
       {
          DataView m_DataView = new DataView(m_DataTable);
          m_DataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
    
          gvSrc.DataSource = m_DataView;
          gvSrc.DataBind();
       }
