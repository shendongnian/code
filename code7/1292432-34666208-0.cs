        [HttpGet]
        [ODataRoute("Contacts/Default.FullNameContains(value={value})")]
        public IHttpActionResult FullNameContains(string value)
        {
            value = value.ToLower();
            return Ok(db.Contacts.ToList().Where(c => c.FullName.Contains(value)));
        }
