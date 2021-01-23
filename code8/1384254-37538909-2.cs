    /// <summary>
    /// Description what the class does
    /// </summary>
    public class MyClass
    {
        /// <summary>
        /// Description what the function does
        /// </summary>
        /// <param name="param1">Description what the parameter does 
        ///   Optional tags inside param1:
        ///    <c></c> <code></code> <list type=""></list> <paramref name="param1"/>
        ///    <para></para>
        /// </param>
        /// <param name="param2">Description what the parameter does</param>
        /// <returns>Description about the return value</returns>
        public string MyMethod(int param1, string param2)
        {
            return "Some value: " + MyProperty;
        }
        /// <summary>
        /// Description what the property does
        /// </summary>
        /// <see cref="MyMethod(int, string)"/>
        string MyProperty { get; set; }
        // optional tags (valid for class and methods):
        /// <completionlist cref=""/>
        /// <example></example>
        /// <exception cref=""></exception>
        /// <include file='' path='[@name=""]'/>
        /// <permission cref=""></permission>
        /// <remarks></remarks>
        /// <see cref=""/>
        /// <seealso cref=""/>
    }
