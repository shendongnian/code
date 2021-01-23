    public class FibonacciController : ApiController
    {
        public IHttpActionResult Get(int fibN)
        {
            Task.Factory.StartNew(() =>
            {
                var fibNResult = FibonacciHelpers.CalculateFibonacci(fibN);
            });
            return Ok();
        }
    }
