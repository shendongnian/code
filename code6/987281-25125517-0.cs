    private String connectionString = "Server=" + SERVER + "\\" + INSTANCE + ";Database=" + DATABASE + ";User Id="+ USER + ";Password=" + PASSWORD + ";"
    protected SQLConnection getConnection()
    {
        return new SQLConnection(connectionString);
    }
