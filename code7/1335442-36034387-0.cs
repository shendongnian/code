    [Serializable]
    public class MaxLengthFieldbyTemplateValidator : StandardValidator
    {
        /// <summary>
        /// The template separator in Parameters field
        /// </summary>
        private const char FieldLengthSeparator = '=';
       
        /// <summary>
        /// The template length separator in Parameters field 
        /// </summary>
        private const char TemplateLengthSeparator = '~';
        /// <summary>
        /// Gets the name.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The validator name.
        /// </value>
        public override string Name
        {
            get
            {
                return "Max Length";
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Data.Validators.FieldValidators.MaxLengthFieldValidator"/> class.
        /// 
        /// </summary>
        public MaxLengthFieldbyTemplateValidator()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Data.Validators.FieldValidators.MaxLengthFieldValidator"/> class.
        /// 
        /// </summary>
        /// <param name="info">The serialization info.
        ///             </param><param name="context">The context.
        ///             </param>
        public MaxLengthFieldbyTemplateValidator(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// When overridden in a derived class, this method contains the code to determine whether the value in the input control is valid.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The result of the evaluation.
        /// 
        /// </returns>
        protected override ValidatorResult Evaluate()
        {
          return  IsValid(GetItem().TemplateID.ToString()) ? ValidatorResult.Valid : this.GetFailedResult(ValidatorResult.CriticalError);
        }
        private bool IsValid(string currentItemTemplateId)
        {
            var validatorParameters = Parameters;
            // parsing all validators,they are splited by & char 
            foreach (var currentParam in validatorParameters)
            {
                //checking if current item template id is in parameters value
                if (currentParam.Value.Contains(currentItemTemplateId))
                {
                    if (currentParam.Value.Contains(TemplateLengthSeparator))
                    {
                        var maxLenghKeyValuePair = currentParam.Value.Split(TemplateLengthSeparator)[1];
                        if (maxLenghKeyValuePair.Contains(FieldLengthSeparator))
                        {
                            var maxLengthValue = maxLenghKeyValuePair.Split(FieldLengthSeparator)[1];
                            int intMaxLengthValue = MainUtil.GetInt(maxLengthValue, 0);
                            string controlValidationValue = this.ControlValidationValue;
                            if (string.IsNullOrEmpty(controlValidationValue) ||
                                controlValidationValue.Length <= intMaxLengthValue)
                            { return true; }
                            else
                            {
                                Text = GetText("The maximum length of the field \"{0}\" is {1} characters.", this.GetFieldDisplayName(), maxLengthValue);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Gets the max validator result.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This is used when saving and the validator uses a thread. If the Max Validator Result
        ///             is Error or below, the validator does not have to be evaluated before saving.
        ///             If the Max Validator Result is CriticalError or FatalError, the validator must have
        ///             been evaluated before saving.
        /// 
        /// </remarks>
        /// 
        /// <returns>
        /// The max validator result.
        /// 
        /// </returns>
        protected override ValidatorResult GetMaxValidatorResult()
        {
            return this.GetFailedResult(ValidatorResult.CriticalError);
        }
    }
