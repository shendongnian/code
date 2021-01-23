    using FluentValidation;
    using FluentValidation.Internal;
    using FluentValidation.Resources;
    using FluentValidation.Results;
    using System;
    using System.Linq;
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
                RuleFor(s => s.Id).NotNull()
                              .GreaterThanOrEqualTo(1)
                              .LessThanOrEqualTo(99)
                              .WithGlobalMessage("Minimum Age entry is required and must range from 1 to 99 years.");
            }
        }
        public class Customer { public int? Id { get; set; } }
        public static class MyExtentions
        {
            public static IRuleBuilderOptions<T, TProperty> WithGlobalMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorMessage)
            {
                foreach (var item in (rule as RuleBuilder<T, TProperty>).Rule.Validators)
                    item.ErrorMessageSource=new StaticStringSource(errorMessage);
            
                return rule;
            }
        }
    }
