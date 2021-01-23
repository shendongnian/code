    from t in Tasks
    join user in UserInfo on t.Publisher equals user.Account into temp
    from userinfo in temp.DefaultIfEmpty()
    select userinfo != null
        ? new
            {
                t.Title,
                IsCertificated = userinfo.IsCertificated
            }
        : new
            {
                t.Title,
                IsCertificated = false
            }
