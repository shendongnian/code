        // POST odata/Foos
        public IHttpActionResult Post(Foo foo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            FakeData.Instance.Foos.Add(foo);
            return Created(foo);
        }
