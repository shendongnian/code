    var cmd = db.Database.Connection.CreateCommand();
    cmd.CommandText = "[dbo].[GetAllBlogsAndPosts]";
    db.Database.Connection.Open();
    var reader = cmd.ExecuteReader();
    // Read first result set
    var blogs = ((IObjectContextAdapter)db).ObjectContext.Translate<EFStoredProcJit.Blog>(reader, "Blogs", MergeOption.AppendOnly);
    // Read 2nd result set
    reader.NextResult();
    var posts = ((IObjectContextAdapter)db).ObjectContext.Translate<EFStoredProcJit.Post>(reader, "Posts", MergeOption.AppendOnly);
