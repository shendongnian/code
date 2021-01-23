    [HttpPost]
    public ViewResult Edit([Bind(Exclude = "IsAdmin")] User user)
    {
        // ...
    }
