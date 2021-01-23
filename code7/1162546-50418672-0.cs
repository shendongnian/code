    /// <summary>
    /// Base Class for entity validator classes that specifies a base validator class
    /// </summary>
    /// <typeparam name="T">The Type being validated</typeparam>
    /// <typeparam name="TBaseClass">The validater assigned to the base type of the type being validated</typeparam>
    public abstract class BaseAbstractValidator<T, TBaseClass> : AbstractValidator<T>
        where TBaseClass : IEnumerable<IValidationRule>
    {
        protected BaseAbstractValidator() => AppendRules<TBaseClass>();
        /// <summary>
        /// Add the set of validation rules
        /// </summary>
        /// <typeparam name="TValidationRule"></typeparam>
        private void AppendRules<TValidationRule>() where TValidationRule : IEnumerable<IValidationRule>
        {
            var rules = (IEnumerable<IValidationRule>)Activator.CreateInstance<TValidationRule>();
            foreach (var rule in rules)
            {
                AddRule(rule);
            }
        }
    }
