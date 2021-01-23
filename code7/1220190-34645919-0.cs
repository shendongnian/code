        public class OutputDataModel
        {
            public OperationResult Result { get; private set; }
            public OutputDataModel(OperationResult result)
            {
                Result = result;
            }
        }
        public class OutputDataModel<TData> : OutputDataModel
        {
            public TData Data { get; private set; }
            public OutputDataModel(OperationResult result)
                : base(result)
            {
            }
            public OutputDataModel(OperationResult result, TData data)
                : this(result)
            {
                Data = data;
            }
        }
