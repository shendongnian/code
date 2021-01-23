    // Workout message colour
    Color messageColor;
    If (outputMessage.Contains("[Info]"))
        messageColor=normalText;
    if (outputMessage.Contains("[SQL]"))
        messageColor = sqlText;
    else if (outputMessage.Contains("[Status]"))
        messageColor = statusText;
    else if (outputMessage.Contains("[Warning]"))
        messageColor = warningText;
    else if (outputMessage.Contains("[Notice]"))
        messageColor = noticeText;
    else if (outputMessage.Contains("[Debug]"))
        messageColor = debugText;
    else if (outputMessage.Contains("[Error]"))
        messageColor = errorText;
    else if (outputMessage.Contains("[Note]"))
        messageColor = statusText;
    else
        messageColor = normalText;
