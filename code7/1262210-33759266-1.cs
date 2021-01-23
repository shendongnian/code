    /// <summary>
    /// Use this method to send photos. On success, the sent Message is returned.
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat</param>
    /// <param name="photo">Photo to send. You can either pass a file_id as String to resend a photo that is already on the Telegram servers, or upload a new photo using multipart/form-data.</param>
    /// <param name="caption">Optional. Photo caption (may also be used when resending photos by file_id).</param>
    /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
    /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
    /// <returns>On success, the sent Message is returned.</returns>
    public async Task<Message> SendPhoto(int chatId, string photo, string caption = "", int replyToMessageId = 0, ReplyMarkup replyMarkup = null)
