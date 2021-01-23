    DateTime CurrentDateStarts = (DateTime)dtBegin.Value;
      
    DateTime CurrentDateEnds = (DateTime)dtEnd.Value;
        
    CurrentDateStarts = (new DateTime(CurrentDateStarts.Year, CurrentDateStarts.Month, CurrentDateStarts.Day));
          
    CurrentDateEnds = (new DateTime(CurrentDateEnds.Year, CurrentDateEnds.Month, CurrentDateEnds.Day)).AddDays(1).AddSeconds(-1);
                //
            
    geststokv1Entities2 con = geststokv1Entities2.newInstance; 
          
    var produit = cmbProduct.SelectedItem.ListObject as stock_produit; 
            
    var result = con.Database.SqlQuery<view_articleanalysis>("call get_articleanalysis(@produit_id)", new MySql.Data.MySqlClient.MySqlParameter("@produit_id", produit.PRODUIT_ID)).ToList();
    
          
    var list = result.Where(x =>  x.FREE_QUANTITY > 0
                 && x.Date_validation >= CurrentDateStarts
                 && x.Date_validation <= CurrentDateEnds
                ).ToList();
    
    
    UGFree.DataSource = list;
