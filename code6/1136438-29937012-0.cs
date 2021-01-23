    public JsonResult GetMessagesforChart(int id)
    {
          DataRepository _messageRepository = new DataRepository();
          var gluc = _messageRepository.GetAllMessages(id);
          var json = JsonConvert.SerializeObject(gluc); // THIS IS A STRING
          return json; // ERROR BECAUSE I WANT IT A JSONRESULT NOT STRING
     }
