		public class ServiceBase
		{
			#region Output parameters
			public IOutputDataModel<TData> SuccessOutput<TData>(TData data)
			{
				return OutputDataModel<TData>.CreateSuccessResult(data);
			}
			public IOutputDataModel<TData> Output<TData>(OperationResult result, TData data)
			{
				return OutputDataModel<TData>.CreateResult(result, data);
			}
			public IOutputDataModel<TData> Output<TData>(OperationResult result)
			{
				return OutputDataModel<TData>.CreateResult(result);
			}
			public IOutputModel SuccessOutput()
			{
				return OutputModel.CreateSuccessResult();
			}
			public IOutputModel Output(OperationResult result)
			{
				return OutputModel.CreateResult(result);
			}
			#endregion Output parameters
		}
