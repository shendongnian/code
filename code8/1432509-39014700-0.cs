    public interface ICalculator
    {
        int Div(int a, int b);
    }
    public class Calculator : ICalculator
    {
        public int Div(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return 0;
            }
        }
    }
    ProxyGenerator generator = new ProxyGenerator();
    Calculator c = generator.CreateClassProxy<Calculator>(new CalculatorInterceptor());
