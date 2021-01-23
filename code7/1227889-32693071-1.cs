    public interface ITransformer<in TInput,out TOutput>
	{
	    TOutput Transform(TInput input);
	}
	public interface ITransform<TInput>
	{
	    TOutput Transform<TOutput>(ITransformer<TInput, TOutput> transformer);
	}
	public class MessageLogs : ITransform<MessageLogs>
	{
		public TOutput Transform<TOutput>(ITransformer<MessageLogs, TOutput> transformer)
		{
			return transformer.Transform(this);
		}
	}
