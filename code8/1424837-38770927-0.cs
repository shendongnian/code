        // The overloads of == and != are included to enable comparisons between
        // XName and string (e.g. element.Name == "foo"). C#'s predefined reference
        // equality operators require one operand to be convertible to the type of
        // the other through reference conversions only and do not consider the
        // implicit conversion from string to XName.
 
        /// <summary>
        /// Returns a value indicating whether two instances of <see cref="XName"/> are equal.
        /// </summary>
        /// <param name="left">The first XName to compare.</param>
        /// <param name="right">The second XName to compare.</param>
        /// <returns>true if left and right are equal; otherwise false.</returns>
        /// <remarks>
        /// This overload is included to enable the comparison between
        /// an instance of XName and string.
        /// </remarks>
        public static bool operator ==(XName left, XName right) {
            return (object)left == (object)right;
        }
