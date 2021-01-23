        [HttpGet, Route("/api/streets/{id:int:min(1)}")]
        public IHttpActionResult GetYourJsonData(int id)
        {
            try
            {
                //from your unit of work class
                return uow.GetEntities<Street>(x => x.ID == id)
                    .FirstOrDefault()
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
   
    //Edit: in your repo class
    public IEnumerable<T> GetEntities<T>(Func<T, bool> predicate) where T : class
    {
        return yourContext.Set<T>().Where(predicate);
    }
