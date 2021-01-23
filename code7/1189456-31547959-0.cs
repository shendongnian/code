    [GET("/users/{id:int}")]
    public User GetUserById(int id)
    {
    }
    [GET("/users/{email:regex(^[^@]+@[^@]$)}")]
    public User GetUserByEmail(string email)
    {
    }
    [GET("/users/{username}")]
    public User GetUserByName(string username)
    {
    }
