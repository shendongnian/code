        [Route("Get")]
        public IHttpActionResult GetVendor()
        {
            var vendor = _ivs.GetVendorDetails();
          
            return Ok(vendor);
        }
