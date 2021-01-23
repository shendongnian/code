    DataTable dtDelete = new DataTable();
    dtDelete = ds_RecipeData.Tables[0]
    if (ds_RecipeData.Tables.Contains(dtDelete.TableName))
        if (ds_RecipeData.Tables.CanRemove(dtDelete))
          ds_RecipeData.Tables.Remove(dtDelete);
    
 
