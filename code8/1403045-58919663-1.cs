        /// <summary>
        /// Returns the caller method name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="caller"></param>
        /// <param name="fullName">if true returns the fully qualified name of the type, including its namespace but not its assembly.</param>
        /// <returns></returns>
        public static string GetMethodName(this object type, [CallerMemberName] string caller = null, bool fullName = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var name = fullName ? type.GetType().FullName : type.GetType().Name;
            return $"{name}.{caller}()";
        }
