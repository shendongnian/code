    [HttpPost]
    [ValidationResponseFilter]
    [Route("")]
    [ResponseType(typeof(List<Reading>))] //will still display response with IsRejected
    public IHttpActionResult Add(List<ReadingVM> readingListVM)
    {
        //Logic here
    }
