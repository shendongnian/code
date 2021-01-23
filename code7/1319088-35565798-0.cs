    using FluentValidation;
    using FluentValidation.Results;
    using FluentValidation.Validators;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer customer = new Customer() { };
                CustomerValidator validator = new CustomerValidator();
                ValidationResult results = validator.Validate(customer);
                Console.WriteLine(results.Errors.First().ErrorMessage);
                Console.ReadLine();
            }
        }
       public class CustomerValidator : AbstractValidator<Customer>
       {
            public CustomerValidator()
            {
                CustomRuleFor(s => s.Id, "Minimum Age entry is required and must range from 1 to 99 years.",
                    new NotNullValidator(),
                    new GreaterThanOrEqualValidator(1),
                    new LessThanOrEqualValidator(99));
            }
           void CustomRuleFor<TProperty>(Expression<Func<Customer, TProperty>> expression,
                                                              string errorMessage,
                                                              params IPropertyValidator[] validators)
            {
                var rule = RuleFor(expression);
                foreach (var item in validators)
                     rule.SetValidator(item).WithMessage(errorMessage);
            }
        }
        public class Customer { public int? Id { get; set; } }
    }
