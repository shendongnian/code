    /// <summary>
    /// Represents a composite key for cached objects
    /// </summary>
    public class MultiKey
    {
        /// <summary>
        /// The type of key
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// The key represents a User Name
            /// </summary>
            UserName,
            /// <summary>
            /// The key represents an Employee Number
            /// </summary>
            EmployeeNumber
        }
        /// <summary>
        /// Gets or sets the Type of the Key.
        /// </summary>
        public Type KeyType { get; set; }
        /// <summary>
        /// Gets or sets the value of the Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Compare based on hash code
        /// </summary>
        /// <param name="obj">the object to compare against</param>
        /// <returns>true if both objects are equals, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is FormCacheKey)
            {
                return (obj as FormCacheKey).GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        /// <summary>
        /// Compares based on hash code
        /// </summary>
        /// <param name="p1">left side of the operator</param>
        /// <param name="p2">right side of the operator</param>
        /// <returns>true if both items are equal, false otherwise</returns>
        public static bool operator ==(FormCacheKey p1, FormCacheKey p2)
        {
            if ((object)p1 == null && (object)p2 == null)
            {
                return true;
            }
            if ((object)p1 == null || (object)p2 == null)
            {
                return false;
            }
            return p1.Equals(p2);
        }
        /// <summary>
        /// Compares based on hash code
        /// </summary>
        /// <param name="p1">left side of the operator</param>
        /// <param name="p2">right side of the operator</param>
        /// <returns>true if both items are different, false otherwise</returns>
        public static bool operator !=(FormCacheKey p1, FormCacheKey p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Returns a hash key code that identifies this object
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            const int CoPrimeNumber = 37;
            var finalHashCode = 17;
            finalHashCode = (finalHashCode * CoPrimeNumber) + this.KeyType.GetHashCode();
            finalHashCode = (finalHashCode * CoPrimeNumber) + this.Key.GetHashCode();
            return finalHashCode;
        }
    }
