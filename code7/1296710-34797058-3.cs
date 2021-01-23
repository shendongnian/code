                --NewObject is a new class that will hold the SQL result
                IQueryable<NewObject> sql = db.TBL_Mapping
                                              .Select(m => new NewObject {
                                                     column1,
                                                     column2,
                                                     //... all the columns
                                              });
                bool HasSystem1 = db.TBL_Mapping.Any(m => m.System1 != null);
                
                //left outer join with System1 if it has it in the TBL_Mapping
                if (HasSystem1)
                {
                    sql = 
                        from m in sql
                        join s1 in db.VW_System1_ALL
                        on m.System1ID equals s1.System1ID into stemp
                        from st in stemp.DefaultIfEmpty()
                        select new { column1 = st.column1, column2 = st.column2, etc }; 
                                    //--get all the columns
                }
                //repeat the same for other system views
                //....
                //at the end do paging.
                var result = sql
                             .Skip(currentPageNumber * numberOfObjectsInPage)
                             .Take(numberOfObjectsInPage);
