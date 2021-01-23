    public class CppInterop : DynamicInterop.UnmanagedDll // http://www.nuget.org/packages/DynamicInterop/
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _c_api_call([In, Out] [MarshalAs(UnmanagedType.LPArray)] int[] values);
        public int[] CreateArray()
        {
            // These two following references could be cached for efficiency later on.
            var getLength = this.GetFunction<_c_api_call_getlength>("c_api_call_getlength");
            var getValues = this.GetFunction<_c_api_call>("c_api_call");
            // As far as I know it is preferable, if not needed, to handle arrays in two steps:
            // we need to know the expected length to allocate in C# buffer memory.
            int expectedLength = getLength();
            int[] result = new int[expectedLength];
            getValues(result);
            return result;
        }
