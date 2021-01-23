    public class ModelNameValidator : IModelValidator<ModelName>
    {
        public ModelNameValidator()
        {
        }
        public IEnumerable<ModelValidationResult> Validate(ModelName model)
        {
            //here now my verification
            if(model.testParamFromUri < 0)
            {
                yield return new ModelValidationResult()
                {
                    MemberName = "testParamFromUri",
                    Message = "Model Error Message Here"
                };
            }
        }
    }
