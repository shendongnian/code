    public JsonResult GetMessagesforChart(int id)
    {
          DataRepository _messageRepository = new DataRepository();
          DataBase gluc = _messageRepository.GetAllMessages(id);
          return JsonConvert.SerializeObject(gluc);
     }
