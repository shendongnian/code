    int closingBracketIndex = outputMessage.IndexOf(']');
    string msgType = closingBracketIndex > 2 ? outputMessage.Substring(1, closingBracketIndex - 1) : string.Empty;
    // Workout message colour
    Color messageColor = typeColors.ContainsKey(msgType) ? typeColors[msgType] : typeColors["Default"];
    // Format message
    outputMessage = FormatOutput(outputMessage);
    // Append message with colour
    RTBAppendText(targetRTB, messageColor, outputMessage);
    ...
