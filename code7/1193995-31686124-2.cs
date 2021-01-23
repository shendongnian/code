    [HttpGet, Route("/api/streets/{id:int:min(1)}")]
    public IHttpActionResult GetYourJsonData(int id)
    {
        try
        {
        return yourContext.Streets
            .FirstOrDefault(x => x.ID == id)
            .Select(viewModel => new {
                ID = viewModel.ID,
                Name = viewModel.Name,
                StreetTypeID = viewModel.StreetType //consider renaming this to streeytype and not street type id
            });
        }
        catch(Exception)
        {
             return InternalServerError();
        }
    }
