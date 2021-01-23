        #region Cached Attribute Retrieval
        /// <summary>Cache of attributes retrieved for members.</summary>
        private static readonly ConcurrentDictionary<Tuple<string, Type, Type>, object>
            CachedPropertyAttributes = new ConcurrentDictionary<Tuple<string, Type, Type>, object>();
        /// <summary>Determines whether the member has the specified attribute defined.</summary>
        /// <typeparam name="T">The type of the attribute to look for.</typeparam>
        /// <param name="member">The member to check if an attribute is defined on.</param>
        /// <returns>True if the attribute is defined.</returns>
        public static bool IsAttributeDefinedFast<T>(this MemberInfo member)
        {
            return IsAttributeDefinedFast(member, typeof(T));
        }
        /// <summary>Determines whether the member has the specified attribute defined.</summary>
        /// <param name="member">The member to check if an attribute is defined on.</param>
        /// <param name="attributeType">The type of the attribute to look for.</param>
        /// <returns>True if the attribute is defined.</returns>
        public static bool IsAttributeDefinedFast(this MemberInfo member, Type attributeType)
        {
            return member.GetCustomAttributeFast(attributeType) != null;
        }
        /// <summary>Gets the specified attribute from the member.</summary>
        /// <typeparam name="T">The type of the attribute to look for.</typeparam>
        /// <param name="member">The member to get the custom attribute of.</param>
        /// <returns>True if the attribute is defined on the specified member.</returns>
        public static T GetCustomAttributeFast<T>(this MemberInfo member)
        {
            return (T)GetCustomAttributeFast(member, typeof(T));
        }
        /// <summary>Gets the specified attribute from the member.</summary>
        /// <param name="member">The member to get the custom attribute of.</param>
        /// <param name="attributeType">The type of the attribute to look for.</param>
        /// <returns>True if the attribute is defined on the specified member.</returns>
        public static object GetCustomAttributeFast(this MemberInfo member, Type attributeType)
        {
            Tuple<string, Type, Type> cacheKey =
                Tuple.Create(member.Name, member.DeclaringType, attributeType);
            object result = CachedPropertyAttributes.GetOrAdd(cacheKey, key =>
            {
                try { return Attribute.GetCustomAttribute(member, attributeType, true); }
                catch (Exception ex) { return ex; }
            });
            if (result is Exception exceptionResult)
                throw exceptionResult;
            return result;
        }
        #endregion Cached Attribute Retrieval
