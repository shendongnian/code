    using UnityEngine.Events;
    
    using CEUtilities.Helpers;
    
    namespace UnityEngine
    {
        public static class UnityEventExtension
        {
            /// <summary>
            /// Clones the specified unity event list.
            /// </summary>
            /// <param name="ev">The unity event.</param>
            /// <returns>Cloned UnityEvent</returns>
            public static T Clone<T>(this T ev) where T : UnityEventBase
            {
                return ReflectionHelper.DeepCopy(ev);
            }
        }
    }
