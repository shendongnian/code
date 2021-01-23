    public IActionResult generatePasswd(int length)
    {
        // Where the generateImpl returns a string.
        return Ok(generateImpl(length));
    }
