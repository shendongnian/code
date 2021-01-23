    public class CustomParameterBinding : HttpParameterBinding
	{
		public CustomParameterBinding( HttpParameterDescriptor p ) : base( p ) { }
		public override System.Threading.Tasks.Task ExecuteBindingAsync( System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken )
		{
			var id = int.Parse( actionContext.Request.RequestUri.Segments.Last() );
			SetValue( actionContext, string.Format( "This is formatted ID value:{0}", id ) );
			var tsc = new TaskCompletionSource<object>();
			tsc.SetResult(null );
			return tsc.Task;
		}
	}
