    public JsonResult Get(string id)
        {
              var data = _service.getData(id);
    
            return Json(data, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                });
    
        }
