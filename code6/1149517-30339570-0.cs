    String query= "SELECT * FROM VW_ASSET_LIST "; // SQL View 
    SqlCommand queryCommand= new SqlCommand(query, connection);
    	        
    SqlDataReader resultsSet= queryCommand.ExecuteReader();
    DataTable dtAsset = new DataTable();
    dtAsset.Load(resultsSet);
    dtgMasterAsset.DataSource = dtAsset;
