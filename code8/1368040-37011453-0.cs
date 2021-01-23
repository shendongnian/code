        [HttpGet]
        [Route("api/my/{id1}/{id2}")]
        [ResponseType(typeof(UserItem))]
        public async Task<IHttpActionResult> GetUserItem(string id1, string id2)
        {
           UserItem item = await db.useritems.FindAsync(id1);
           ......
        }
