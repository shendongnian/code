    public JsonResult Action() {
        var json = new JsonResult();
        
        json.Body = new {
            List1 = L1, Dictionary = v
        };
        
        return json;
    }
