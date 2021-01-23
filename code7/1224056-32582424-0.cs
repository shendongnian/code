    using System;
    using System.Reflection;
    using System.Web.Mvc;
    /// <summary>
    /// The MultipleButtonAttribute class is a custom attribute to cater for a view form with multiple submit buttons.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }
        /// <summary>Determines whether the action name is valid in the specified controller context.</summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionName">The name of the action.</param>
        /// <param name="methodInfo">Information about the action method.</param>
        /// <returns>True if the action name is valid in the specified controller context; otherwise, false.</returns>
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var keyValue = string.Format("{0}:{1}", this.Name, this.Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);
            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[this.Name] = this.Argument;
                isValidName = true;
            }
            return isValidName;
        }
