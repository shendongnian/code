     using Sitecore.Globalization;
     using System.ComponentModel.DataAnnotations;
     using System.Runtime.CompilerServices;
     public class CustomRequiredAttribute : RequiredAttribute
    {
        /// <summary>
        /// The _property name
        /// </summary>
        private string propertyName;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRequiredAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public CustomRequiredAttribute([CallerMemberName] string propertyName = null)
        {
            this.propertyName = propertyName;
        }
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName
        {
            get { return this.propertyName; }
        }
        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>
        /// An instance of the formatted error message.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.GetErrorMessage(), name);
        }
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>Error message</returns>
        private string GetErrorMessage()
        {
            return Translate.Text(this.ErrorMessage);
        }
    }
