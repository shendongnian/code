    public ItemControllerV2 : ApiController
    {
        [Route("v2/item/{id:int}")]
        public Item Get(int id)
        {
            ....
        }
    }
