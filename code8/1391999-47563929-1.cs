    [HttpPost]
    Route("api/Values/emptycardlist")
    public HttpResponseMessage EmptyCardList([FromBody] dynamic dynObject){
        if(dynObject.Type == "Array") {
            // Handle list
        }
        // Handle response
    }
