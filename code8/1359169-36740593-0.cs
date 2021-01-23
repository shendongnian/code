    var sql = @"
        SELECT 
            p.Name AS PuzzleName, 
            up.Minute, 
            up.Session 
        FROM UserProgresses as up
        INNER JOIN Puzzles as p ON p.Id = up.PuzzleId 
        WHERE up.UserId = @userid
    ";
    // Instead of console, you may want to use your default app logging.
    ctx.Database.Log += (message) => Console.WriteLine(message);
    ctx
        .Database
        .SqlQuery<UserProgressViewModel>(sql, new SqlParameter("@userid", userid))
        .ToList();
