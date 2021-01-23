              public class AWValidation
                {
                        public static ValidationResult ValidateSalesAmount(int salesAmount,ValidationContext validationContext)
                         {
                           if (salesAmount < 0)
                              {
                               return new ValidationResult("Invalid Sales Amount");
                              }
                          return ValidationResult.Success;
                         }
               }
