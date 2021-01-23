    public class AddNewRow
    {
        public static Func<DatabaseDataContext, DateTime, int, bool>
            GetNewRowMissingData =
                     CompiledQuery.Compile((DatabaseDataContext db, DateTime dDate, int staffNo) =>
                     db.Staff_Time_TBLs.Any(a => a.Date_Data == dDate && a.Staff_No == staffNo));
    }
