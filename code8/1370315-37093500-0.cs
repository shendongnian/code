            if (!photoManager.FileExists(fileName))
            {
                return NotFound();
            }
            var result = await photoManager.Delete(fileName);
            if (result.Successful)
            {
                return Ok(
                    new {
                            message = result.Message
                        }
                    );
            }
            else
            {
                return BadRequest(result.Message);
            }
