        enter code here
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    namespace Attributes
    {
        [AttributeUsage(AttributeTargets.Property)]
        public sealed class MinimumPaymentDateAttribute : ValidationAttribute, IClientValidatable
        {
            private readonly string errorMessage;
            public string ValidationErrorMessage { get { return errorMessage; } }
            /// <summary>
            /// Constructor for intializing variables
            /// </summary>
            public MinimumPaymentDateAttribute()
            {
            }
    
            /// <summary>
            ///  Constructor for intializing variables
            /// </summary>
            /// <param name="validationErrorMessage"></param>
            public MinimumPaymentDateAttribute(string validationErrorMessage)
            {
                this.errorMessage = validationErrorMessage;
            }
            /// <summary>
            /// Validation for of Rule implement Client Validation
            /// </summary>
            /// <param name="value"></param>
            /// <param name="validationContext"></param>
            /// <returns></returns>
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (null != validationContext)
                {
                    PaymentInformation paymentInfo = (PaymentInformation)validationContext.ObjectInstance;
                    if (value != null && validationContext != null)
                    {
                        if (paymentInfo.PaymentDate < paymentInfo.MinDate)
                        {
                            return new ValidationResult(this.ValidationErrorMessage);
                        }
                    }
                }
                return ValidationResult.Success;
            }
    
            /// <summary>
            ///  Validation rules client side for Minimum Date
            /// </summary>
            /// <param name="metadata"></param>
            /// <param name="context"></param>
            /// <returns>IEnumerable<ModelClientValidationRule></returns>
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
                ModelClientValidationRule MinDateRule = new ModelClientValidationRule();
                DateTime? validationData = GetValidationParameters(context.Controller.ViewData.Model);
                MinDateRule.ErrorMessage = errorMessage;
                MinDateRule.ValidationType = "validminpaymentdate";(Java script function name)
                MinDateRule.ValidationParameters.Add("mindate", validationData);
                yield return MinDateRule;
            }
    
    
            /// <summary>
            ///  Checking for Model type for handling Different ViewData
            /// </summary>
            /// <param name="model"></param>   
            /// <returns>string[]</returns>
            private static DateTime? GetValidationParameters(object model)
            {
                DateTime? MinDate=null;
                if (model.GetType() == typeof(PaymentInformation))
                {
                    PaymentInformation obj = (PaymentInformation)model;
                    return obj.MinDate;
                }
                else if (model.GetType() == typeof(PaymentViewModel))
                {
                    PaymentViewModel obj = (PaymentViewModel)model;
                    return obj.PaymentInfo.MinDate;
                }
                return MinDate;
            }
        }
    }
    $.validator.addMethod("validminpaymentdate", function (value, element, params) {
        var valid = true;
        var mindate = new Date(params);
        var valdate = new Date(value);
        if (valdate < mindate) {
            valid = false;
        }
        return valid;
    
    });
    $.validator.unobtrusive.adapters.addSingleVal("validminpaymentdate", "mindate");
