    /// <summary>
    /// Class for conversion of binding-attributes while XML-serialization.
    /// With this converter it is possible to serialize the control-bindings.
    /// Works together with the class EditorHelper.
    /// </summary>
    public class BindingConvertor : ExpressionConverter
    {
        /// <summary>
        /// Finds out if the converter can convert an expression-object to the given destinationtype.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext-interface which provides a context for formatting.</param>
        /// <param name="destinationType">A type-class which represents the target-type of the conversion.</param>
        /// <returns>Returns an object of type bool. True = the destinationtype can be converted.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(MarkupExtension))
                return true;
            return false;
        }
        /// <summary>
        /// Converts the expression to the given destinationtype.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext-interface which provides a context for formatting.</param>
        /// <param name="culture">The System.Globalization.CultureInfo which is actually used as culture.</param>
        /// <param name="value">The object to convert.</param>
        /// <param name="destinationType">A type-class which represents the target-type of the conversion.</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value,
            Type destinationType)
        {
            if (destinationType == typeof(MarkupExtension))
            {
                BindingExpression bindingExpression = value as BindingExpression;
                if (bindingExpression == null)
                    throw new Exception();
                return bindingExpression.ParentBinding;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
