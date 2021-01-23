    [HttpDelete("api/any")]
    public IActionResult Delete([FromForm]List<long> ids)
    {
         try
         {
             _service.Delete(ids);
              return new HttpOkResult();
         }
         catch (Exception)
         {
            return new BadRequestObjectResult("Error");
         }
    }
