                bool HasSystem1 = db.TBL_Mapping.Any(m => m.System1 != null);
                IQueryable<NewObject> sql = db.TBL_Mapping;
                if (HasSystem1)
                {
                    sql = 
                        from m in sql
                        join s1 in db.VW_System1_ALL
                        on m.System1ID equals s1.System1ID into stemp
                        from st in stemp.DefaultIfEmpty()
                        select new { [columns] };
                }
                //repeat for other system views
                //....
                //at the end do paging.
                sql.Skip(currentPageNumber * numberOfObjectsInPage).Take(numberOfObjectsInPage);
