    public static class CompiledQueries
        {
            public static Func<DatabaseDataContext, string, IQueryable<Staff_Time_TBL>>
                 sectionEmployess = CompiledQuery.Compile((DatabaseDataContext database, string section) =>
                      database.Staff_Time_TBLs.Where(staff => staff.Section_Data == section));
        }
