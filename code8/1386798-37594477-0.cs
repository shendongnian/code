    var validationResults = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(searchCriteria, new ValidationContext(searchCriteria, null, null), validationResults, true);
            if (!isValid)
            {
                foreach (var result in validationResults)
                {
                    bindingContext.ModelState.AddModelError("", result.ErrorMessage);
                }
            }
