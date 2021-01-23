        public async Task<T2> GenericAsyncCall<T1, T2>(Func<T1, T2> GenericMethod, T1 input)
        {
            var _output = await Task.Factory.StartNew(() => {
                var output = GenericMethod.Invoke(input);
                return output;
            });
            return (T2)_output;
        }
