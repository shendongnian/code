    /// <summary>
    /// Class for registering the class BindingConvertor as the type-converter for the type BindingExpression
    /// With this converter it is possible to serialize the control-bindings.
    /// </summary>
    public class EditorHelper
    {
        /// <summary>
        /// Registers which converter is responsible for which type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <typeparam name="TC">The converter.</typeparam>
        public static void Register<T, TC>()
        {
            Attribute[] attribute = new Attribute[1];
            TypeConverterAttribute typeConverterAttribute = new TypeConverterAttribute(typeof(TC));
            attribute[0] = typeConverterAttribute;
            TypeDescriptor.AddAttributes(typeof(T), attribute);
        }
    }
