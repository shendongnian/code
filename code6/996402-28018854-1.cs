    public object BeforeCall(string operationName, object[] inputs)
                  {
                    var validationResults = new List<ValidationResult>();             	ErrorMessageGenerator.isValidationFail = false;
                    ErrorMessageGenerator.ErrorMessage = string.Empty;
                    ***inputs=ValidateCollection( operationName, inputs);***
                    foreach (var input in inputs)
    	{
                       foreach (var validator in _validators)
                        {
                            var results = validator.Validate(input);
                            validationResults.AddRange(results);
                        }
                   }
                          if (validationResults.Count > 0)
                    {
                      return _errorMessageGenerator.GenerateErrorMessage(operationName, validationResults);
                    }
                    return null;
                }
      private object[] ValidateCollection(string operationName, object[] inputs)
            {
                object[] inputs1 = inputs;
                try
                {
                    foreach (var input in inputs)
                    {
                        foreach (var property in input.GetType().GetProperties())
                        {
                            IEnumerable enumerable = null;
                            if (property.PropertyType.Name.Contains("List"))
                            {
                                enumerable = property.GetValue(input, null) as IEnumerable;
                                int j = 0;
              object[] o1 = new object[inputs.Count() + enumerable.OfType<object>().Count()];
                                for (int k = 0; k < inputs.Count(); k++)
                                {
                                    o1[k] = inputs[k];
                                }
                                foreach (var item in enumerable)
                                {
    
                                    o1[inputs.Count() + j] = item;
                                    j = j + 1;
                                    if (j == (o1.Length - inputs.Count()))
                                        inputs = o1;
                                }
                            }
    
                        }
                    }
                    return inputs;
                }
                catch
                {
                    return inputs1;
                }
                
            }
