    private delegate bool ParseMessageWrapper(Message msg, out byte resp);
    void IncomingMessageSwitchStatements(Message msg, Host host)
    {
        byte resp = 0;
        bool output = false;
        var parseMethods = new List<ParseMessageWrapper>()
        {
            new ParseMessageWrapper(ParseMessageOptionOne),
            new ParseMessageWrapper(ParseMessageOptionTwo),
            new ParseMessageWrapper(ParseMessageOptionThree)
        };
        output = parseMethods.Any(func => func.Invoke(msg, out resp));
        if (output && resp == 0x01)
        {
            UpdateUiFromHere();
        }
    }
