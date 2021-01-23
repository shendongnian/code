        [Route("Get")]
        public IHttpActionResult Vendor()
        {
            var vendor = _ivs.GetVendorDetails();
          
            return Ok(vendor);
        }
