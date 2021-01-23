    public async ReadOnlyCollection<string> GetUserNames()
    {
    // Request userNames from server
    List<UserNames> userNameList = await ReceiveMessages();
    // return userNames
    }
    // Running on seperate thread, gets messages that server sents to client
    async Task<List<UserNames> ReceiveMessages()
    {
    // Looks what message contains
    // Gets collection of userNames when requested (Working)
    // Triggers event 'UserNamesArrived' with userNames as argument
    }
