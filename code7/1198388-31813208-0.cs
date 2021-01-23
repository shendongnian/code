        static void Main(string[] args)
        {
            var a = JsonConvert.DeserializeObject<DataTable>("-- JSON STRING --", new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
        }
        public static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
