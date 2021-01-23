    db.Insert(new Record { ... }.WithAudit(Request.GetSession().UserAuthId));
    //Extension Method Example:
    public static class RecordManagementExtensions
    {
        public static T WithAudit<T>(this T row, string userId) where T : IRecordManagement
        {
            row.UserId = userId;
            row.DateCreated = DateTime.UtcNow;
            return row;
        }
    }
