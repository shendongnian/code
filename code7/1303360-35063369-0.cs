    // POST tables/TodoItem
    public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
    {
      try
      {
        TodoItem current = await InsertAsync(item);
        return CreatedAtRoute("Tables", new { id = current.Id }, current);
      }
      catch (HttpResponseException ex)
      {
        string message = ((HttpError)((ObjectContent)ex.Response.Content).Value).First().Value.ToString();
        string[] temp = message.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
          Content = new StringContent(message),
          ReasonPhrase = temp[0]
        };
        throw new HttpResponseException(resp);
      }
    }
