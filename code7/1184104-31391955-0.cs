    public async Task<IHttpActionResult> GetMessages()
    {
      var result = await _messageRepository.GetMessagesAsync();
      return Ok(result);
    }
