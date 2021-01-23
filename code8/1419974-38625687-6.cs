    this.UIThread(() =>
    {
        string msgType = outputMessage.Substring(1, outputMessage.IndexOf(']') - 1);
        // Workout message colour
        Color messageColor = normalText;
        switch (msgType)
        {
            case "SQL": messageColor = sqlText;
                break;
            case "Status": messageColor = statusText;
                break;
            case "Warning": messageColor = warningText;
                break;
            case "Notice": messageColor = noticeText;
                break;
            case "Debug": messageColor = debugText;
                break;
            case "Error": messageColor = errorText;
                break;
            case "Note": messageColor = statusText;
                break;
        }
        // Format message
        outputMessage = FormatOutput(outputMessage);
        // Append message with collour
        RTBAppendText(targetRTB, messageColor, outputMessage);
        ...
    }
