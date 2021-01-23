                bool HasSystem1 = db.TBL_Mapping.Any(m => m.System1 != null);
                --NewObject is a new class that will hold the SQL result
                IQueryable<NewObject> sql = db.TBL_Mapping;
                if (HasSystem1)
                {
                    sql = 
                        from m in sql
                        join s1 in db.VW_System1_ALL
                        on m.System1ID equals s1.System1ID into stemp
                        from st in stemp.DefaultIfEmpty()
                        select new { columns = st.[columns] }; --all the columns
                }
                //repeat for other system views
                //....
                //at the end do paging.
                var result = sql
                             .Skip(currentPageNumber * numberOfObjectsInPage)
                             .Take(numberOfObjectsInPage);
