    connection.Execute("AddNewNews", new {
        title = news.Title,
        //...
        id_writer = news.Id_writer,
        id_subject1 = subject[0],
        //...
        id_subject5 = subject[4],
    }, commandType: CommandType.StoredProcedure);
