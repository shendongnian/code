    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
      if (IsNotValid(CanBeRenamed)) {
        yield return new ValidationResult(
          $"Property {nameof(CanBeRenamed)} is not valid",
          new [] { $"{nameof(CanBeRenamed)}" })
      }
    }
