    public void CreateSubscription(string name){        
        _productState.CreateSubscription(name); 
    }
    public class ProductState
    {
        public void CreateSubscription(string name)
        {
            if (this.CanCreateSubscription())
            {
                _subscriptions.Add(Subscription.Create(name));
            }
        }
    }
