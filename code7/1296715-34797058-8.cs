    IQueryable<MappingData> sql = db.TBL_Mapping
                                  .Select(m => new MappingData {
                                                     MappingId = ID,
                                                     KeyValueUniqueKey = KeyValueUniqueKey,
                                                     ValueKeyUniqueKey = ValueKeyUniqueKey,
                                                     //leave other columns out
                                                     //they will be filled in 
                                                     //dynamically
                                         })
                                  .Distinct();//get distinct
    //--------------------
    //REPEAT START
    bool HasSystem1 = db.TBL_Mapping.Any(m => m.System1 != null);
                
    //left outer join with System1 if it has it in the TBL_Mapping
    if (HasSystem1)
    {
        sql = 
             from m in sql
             join s1 in db.VW_System1_ALL
             on m.System1ID equals s1.System1ID into stemp
             from st in stemp.DefaultIfEmpty()
             select new { MappingId = st.Id, 
                          KeyValueUniqueKey = st.KeyValueUniqueKey, 
                          ValueKeyUniqueKey = st.ValueKeyUniqueKey, 
                          System1 = st.System1 }; //SystemX column.
    }    
    //REPEAT END
    //--------------------
    // repeat the above for System2 thru System6
    //And in the end do paging.
    var result = sql
                    .Skip(currentPageNumber * numberOfObjectsInPage)
                    .Take(numberOfObjectsInPage);
