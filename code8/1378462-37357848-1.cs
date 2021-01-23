            // arrange
			var validation = Substitute.For<IValidationResult>();
			validation.IsValid.Returns(false);
			validation.Errors.Returns (new List<IValidationError> ());
			validation.Errors.Add (new ValidationError { Message = "sample error" });
            _contratoFactory.Build(ContratoValues.ContratoComEmpresaNula).Returns(validation);
            // act ...
