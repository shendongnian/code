    namespace SupRep.TestUtilities
    {
        using System.Reflection;
        using Moq.Language;
        using Moq.Language.Flow;
    
        public static class MoqExtensions
        {
            public delegate void OutAction<TOut>(out TOut outVal);
            public delegate void OutAction<in T1,TOut>(T1 arg1, out TOut outVal);
            public delegate void OutAction<in T1,in T2,TOut>(T1 arg1, T2 arg2, out TOut outVal);
    
            public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, TOut>(this ICallback<TMock, TReturn> mock, OutAction<TOut> action)
                where TMock : class
            {
                return OutCallbackInternal(mock, action);
            }
    
            public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, TOut>(this ICallback<TMock, TReturn> mock, OutAction<T1, TOut> action)
                where TMock : class
            {
                return OutCallbackInternal(mock, action);
            }
    
            public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, T2, TOut>(this ICallback<TMock, TReturn> mock, OutAction<T1, T2, TOut> action)
                where TMock : class
            {
                return OutCallbackInternal(mock, action);
            }
    
            private static IReturnsThrows<TMock, TReturn> OutCallbackInternal<TMock, TReturn>(ICallback<TMock, TReturn> mock, object action)
                where TMock : class
            {
                var methodCall = mock.GetType().GetProperty("Setup").GetValue(mock);
                mock.GetType().Assembly.GetType("Moq.MethodCall")
                    .InvokeMember("SetCallbackResponse", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, methodCall,
                        new[] { action });
                return mock as IReturnsThrows<TMock, TReturn>;
            }
        }}
