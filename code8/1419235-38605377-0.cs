        [HttpPost, Route("{propertyId}")]
        public IHttpActionResult UpdateProperty(string propertyId, 
            [FromBody] PropertyVM property)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                try
                {
                    property.PropertyId = propertyId;
                    success = _inventoryDAL.UpdateProperty(property);
                }
                catch (Exception ex) //business exception errors
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
                return ResponseMessage(
                    Request.CreateResponse(HttpStatusCode.BadRequest, errors));
            }
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
