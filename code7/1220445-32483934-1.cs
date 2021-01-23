	public class OrdersViewModel : OrdersModel
	{
		public new string orderType {
			get 
			{
				switch(((OrdersModel)this).orderType) 
				{
					case(0):
						return ("Standard Shipping");
					case (1):
						return ("Express Shipping");
					default:
						return ("Value Shipping");
				}
			}
			set{ /* reverse mapping from string to int */ ;}    
		}
	}
