        public class OutputModel
        {
            [JsonIgnore]
            public OperationResult Result { get; private set; }
            public OutputDataModel(OperationResult result)
            {
                Result = result;
            }
			#region Initializatiors
			public static OutputModel CreateResult(OperationResult result)
			{
				return new OutputModel(result);
			}
			public static OutputModel CreateSuccessResult()
			{
				return new OutputModel(OperationResult.Success);
			}
			#endregion Initializatiors
        }
        public class OutputDataModel<TData> : OutputModel
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
			#region Initializatiors
			public static OutputDataModel<TData> CreateSuccessResult(TData data)
			{
				return new OutputDataModel<TData>(OperationResult.Success, data);
			}
			public static OutputDataModel<TData> CreateResult(OperationResult result, TData data)
			{
				return new OutputDataModel<TData>(result, data);
			}
			public new static OutputDataModel<TData> CreateResult(OperationResult result)
			{
				return new OutputDataModel<TData>(result);
			}
			#endregion Initializatiors
        }
