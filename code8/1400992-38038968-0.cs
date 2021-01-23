    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer[] customers = new Customer[100];
                customers[0] = new NormalCustomer();
                customers[1] = new NormalCustomer();
                customers[2] = new SubscriberCustomer();
                customers[3] = new NormalCustomer();
                customers[4] = new SubscriberCustomer();
                int normalCount = 0;
                int subscriberCount = 0;
                foreach (Customer customer in customers)
                {
                    if (customer != null)
                    {
                        string customerName = customer.GetType().ToString();
                        // get name without namespace
                        customerName = customerName.Substring(customerName.LastIndexOf(".") + 1);
                        switch (customerName)
                        {
                            case "NormalCustomer":
                                normalCount++;
                                break;
                            case "SubscriberCustomer":
                                subscriberCount++;
                                break;
                        }
                    }
                }
            }
        }
        abstract class Customer
        {
            public int id;
            public string name;
            public double balance;
        }
        class NormalCustomer : Customer
        {
        }
        class SubscriberCustomer : Customer
        {
            public int LandMinutes;
            public int MobileMinutes;
        }
    }
