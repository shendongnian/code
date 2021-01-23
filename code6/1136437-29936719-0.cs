    public JsonResult GetMessagesforChart(int id)
    {
        DataRepository _messageRepository = new DataRepository();
        var gluc = _messageRepository.GetAllMessages(id);
        return Json(gluc);
    }
