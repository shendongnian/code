public class HttpGlobalExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {...}
}
services.AddMvc(options =>
{
  options.Filters.Add(typeof(HttpGlobalExceptionFilter));
})
