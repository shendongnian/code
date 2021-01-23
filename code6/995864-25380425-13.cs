    // alternatively: async void ParseWordData(). 
    // async void => Task as return type
    // async Task => Task<Task> as return type
    Task ParseWordData() 
    {
        return Task.Run( () => {
            try
            {
                _ParsedWordString = _wordReader.ReadWordDocWithForms(_WordFileLocation);
                Text = "Parsed Word Document";
            }
            catch (Exception)
            {
                Text = "Could not parse Word Document";
            }
        });
    }
