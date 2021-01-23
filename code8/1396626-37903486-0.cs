           public string someRequest()
        {
            try
            {
                var response = await client.SendAsync(request);
                return "Ok";
            }
            catch (Exception e)
            {
             return e.Message;
            }
        }
