    SqlParameter[] parameterList = new SqlParameter[]
    {
        new SqlParameter("@CreatedBy", Int32.Parse(User.Identity.GetUserId())),
        new SqlParameter("@CreatedDate", DateTime.UtcNow),
        new SqlParameter("@TestId", testId),
        new SqlParameter("@TestStatusId", 3)
    };
