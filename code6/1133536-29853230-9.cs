        [HttpPost]
        public IHttpActionResult SomeAction(SomeInput input)
        {
            // Do whatever...
            if (resultIsValid)
            {
                return Ok(outputObject);
            }
            return ValidationResult(errorMessage);
        }
