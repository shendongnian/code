    public class Service : IService
        {
            public string Calculate(int price, int Qty)
            {
                return Convert.ToString(price * Qty);
            }
        } 
