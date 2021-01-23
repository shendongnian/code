            if (ModelState.IsValid)
            {
                ...
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new
                {
                    x.Key,
                    x.Value.Value,
                    x.Value.Errors
                }).ToArray();
            }
