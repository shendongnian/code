    using System;
    using System.Diagnostics;
    using System.Reflection;
    namespace BarCap.RiskServices.RateSubmissions.Utility
    {
    #if (NET20 || NET35 || NET40)
            public class UriQuirksVersionPatcher : IDisposable
            {
                public void Dispose()
                {
                }
            }
    #else
        public class UriQuirksVersionPatcher : IDisposable
        {
            private const string _quirksVersionFieldName = "s_QuirksVersion"; //See Source\ndp\fx\src\net\System\_UriSyntax.cs in NexFX sources
            private const string _uriQuirksVersionEnumName = "UriQuirksVersion";
            /// <code>
            /// private enum UriQuirksVersion
            /// {
            ///     V1 = 1, // RFC 1738 - Not supported
            ///     V2 = 2, // RFC 2396
            ///     V3 = 3, // RFC 3986, 3987
            /// }
            /// </code>
            private const string _oldQuirksVersion = "V2";
            private static readonly Lazy<FieldInfo> _targetFieldInfo;
            private static readonly Lazy<int?> _patchValue;
            private readonly int _oldValue;
            private readonly bool _isEnabled;
            static UriQuirksVersionPatcher()
            {
                var targetType = typeof(UriParser);
                _targetFieldInfo = new Lazy<FieldInfo>(() => targetType.GetField(_quirksVersionFieldName, BindingFlags.Static | BindingFlags.NonPublic));
                _patchValue = new Lazy<int?>(() => GetUriQuirksVersion(targetType));
            }
            public UriQuirksVersionPatcher()
            {
                int? patchValue = _patchValue.Value;
                _isEnabled = patchValue.HasValue;
                if (!_isEnabled) //Disabled if it failed to get enum value
                {
                    return;
                }
                int originalValue = QuirksVersion;
                _isEnabled = originalValue != patchValue;
                if (!_isEnabled) //Disabled if value is proper
                {
                    return;
                }
                _oldValue = originalValue;
                QuirksVersion = patchValue.Value;
            }
            private int QuirksVersion
            {
                get
                {
                    return (int)_targetFieldInfo.Value.GetValue(null);
                }
                set
                {
                    _targetFieldInfo.Value.SetValue(null, value);
                }
            }
            private static int? GetUriQuirksVersion(Type targetType)
            {
                int? result = null;
                try
                {
                    result = (int)targetType.GetNestedType(_uriQuirksVersionEnumName, BindingFlags.Static | BindingFlags.NonPublic)
                                            .GetField(_oldQuirksVersion, BindingFlags.Static | BindingFlags.Public)
                                            .GetValue(null);
                }
                catch
                {
    #if DEBUG
                    Debug.WriteLine("ERROR: Failed to find UriQuirksVersion.V2 enum member.");
                    throw;
    #endif
                }
                return result;
            }
            public void Dispose()
            {
                if (_isEnabled)
                {
                    QuirksVersion = _oldValue;
                }
            }
        }
    #endif
    }
