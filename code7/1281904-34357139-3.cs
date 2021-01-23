    public interface IValidator {
      bool IsDisabled {get; set; }
      void Validate(Delegate addErrorMessage);
    }
    public abstract class BaseValidator : IValidator {
      public bool IsDisabled { get; set; }
      public void Validate(Delegate addErrorMessage) {
        if(!IsDisabled) {
          DoValidations(addErrorMessage);
        }
      }
      
      protected abstract DoValidations(Delegate addErrorMessage);
    }
