    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class MaximumLengthAttribute : MaxLengthAttribute
    {
        /// <summary>
        /// MaxLength with a custom and localized error message
        /// </summary>
        public MaximumLengthAttribute(int maximumLength) : base(maximumLength)
        {
            base.ErrorMessageResourceName = "MaximumLength";
            base.ErrorMessageResourceType = typeof(Resources);
        }
    }
