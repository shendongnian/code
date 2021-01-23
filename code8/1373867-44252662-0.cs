    using Microsoft.Extensions.DependencyInjection;
    using System;
    
    namespace DiSample
    {
        // STEP 1: Define an interface.
        /// <summary>
        /// Defines how a user is notified. 
        /// </summary>
        public interface INotifier
        {
            void Send(string from, string to, string subject, string body);
        }
    
        // STEP 2: Implement the interface
        /// <summary>
        /// Implementation of INotifier that notifies users by email.
        /// </summary>
        public class EmailNotifier : INotifier
        {
            public void Send(string from, string to, string subject, string body)
            {
                // TODO: Connect to something that will send an email.
            }
        }
    
        // STEP 3: Create a class that requires an implementation of the interface.
        public class ShoppingCart
        {
            INotifier _notifier;
    
            public ShoppingCart(INotifier notifier)
            {
                _notifier = notifier;
            }
    
            public void PlaceOrder(string customerEmail, string orderInfo)
            {
                _notifier.Send("admin@store.com", customerEmail, $"Order Placed", $"Thank you for your order of {orderInfo}");
            }
    
        }
    
        public class Program
        {
            // STEP 4: Create console app to setup DI
            static void Main(string[] args)
            {
                // create service collection
                var serviceCollection = new ServiceCollection();
    
                // ConfigureServices(serviceCollection)
                serviceCollection.AddTransient<INotifier, EmailNotifier>();
    
                // create service provider
                var serviceProvider = serviceCollection.BuildServiceProvider();
    
                // This is where DI magic happens:
                var myCart = ActivatorUtilities.CreateInstance<ShoppingCart>(serviceProvider);
    
                myCart.PlaceOrder("customer@home.com", "2 Widgets");
    
                System.Console.Write("Press any key to end.");
                System.Console.ReadLine();
            }
        }
    }
