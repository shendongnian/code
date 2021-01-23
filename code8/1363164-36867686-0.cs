    //-----------------------------------------------------------------------
    // <copyright file="PlaceOrderUpgrade.cs" company="Softlayer">
    //     SoftLayer Technologies, Inc.
    // </copyright>
    // <license>
    // http://sldn.softlayer.com/article/License
    // </license>
    //-----------------------------------------------------------------------
    namespace VirtualGuests
    {
        using System;
        using System.Collections.Generic;
        class PlaceOrderUpgrade
        {
            /// <summary>
            ///  Order an upgrade for Virtual Guest
            ///  This script orders an upgrade for Virtual Guest, in this case we will upgrade the ram for a Virtual Guest,
            ///  It uses SoftLayer_Container_Product_Order_Virtual_Guest_Upgrade container and SoftLayer_Product_Order::placeOrder
            ///  method for it.
            ///  For more information, review the following links:
            /// </summary>
            /// <manualPages>
            /// http://sldn.softlayer.com/reference/services/SoftLayer_Product_Order/placeOrder
            /// http://sldn.softlayer.com/reference/datatypes/SoftLayer_Container_Product_Order_Virtual_Guest_Upgrade/
            /// http://sldn.softlayer.com/reference/services/SoftLayer_Product_Item_Price/
            /// </manualPages>
            static void Main(String [] args)
            {
                // You SoftLayer username
                string username = "set me";
                // Your SoftLayer API key.            
                string apiKey = "set me";
                // Define the virtual guest id to place an upgrade
                int virtualId = 13115425;
                // Creating a connection to the SoftLayer_Product_Order API service and             
                // bind our API username and key to it.           
                authenticate authenticate = new authenticate();
                authenticate.username = username;
                authenticate.apiKey = apiKey;
    
                SoftLayer_Product_OrderService orderService = new SoftLayer_Product_OrderService();
                orderService.authenticateValue = authenticate;
                // Build a SoftLayer_Product_Item_Price objects with the ids from prices that you want to order. 
                // You can retrieve them with SoftLayer_Product_Package::getItemPrices method
                int[] prices = {
                                    1645
                                };
                List<SoftLayer_Product_Item_Price> pricesList = new List<SoftLayer_Product_Item_Price>();
                foreach (var price in prices)
                {
                    SoftLayer_Product_Item_Price newPrice = new SoftLayer_Product_Item_Price();
                    newPrice.id = price;
                    newPrice.idSpecified = true;
                    pricesList.Add(newPrice);
                }
    
                // Build SoftLayer_Container_Product_Order_Property object for the upgrade
                SoftLayer_Container_Product_Order_Property property = new SoftLayer_Container_Product_Order_Property();
                property.name = "MAINTENANCE_WINDOW";
                property.value = "NOW";
                
                List<SoftLayer_Container_Product_Order_Property> propertyList = new List<SoftLayer_Container_Product_Order_Property>();
                propertyList.Add(property);
    
                // Build SoftLayer_Virtual_Guest object with the id from vsi that you wish to place an upgrade
                SoftLayer_Virtual_Guest virtualGuest = new SoftLayer_Virtual_Guest();
                virtualGuest.id = virtualId;
                virtualGuest.idSpecified = true;
    
                List<SoftLayer_Virtual_Guest> virtualGuests = new List<SoftLayer_Virtual_Guest>();
                virtualGuests.Add(virtualGuest);
    
                // Build SoftLayer_Container_Product_Order object containing the information for the upgrade
                //SoftLayer_Container_Product_Order orderTemplate = new SoftLayer_Container_Product_Order();
                SoftLayer_Container_Product_Order_Virtual_Guest_Upgrade orderTemplate = new SoftLayer_Container_Product_Order_Virtual_Guest_Upgrade();
                orderTemplate.containerIdentifier = "SoftLayer_Container_Product_Order_Virtual_Guest_Upgrade";
                orderTemplate.prices = pricesList.ToArray();
                orderTemplate.properties = propertyList.ToArray();
                orderTemplate.virtualGuests = virtualGuests.ToArray();
                try
                {
                    // We will check the template for errors, we will use the verifyOrder() method for this. 
                    // Replace it with placeOrder() method when you are ready to order.
                    SoftLayer_Container_Product_Order verifiedOrder = orderService.verifyOrder(orderTemplate);
                    Console.WriteLine("Order Verified!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to place an upgrade for Virtual Guest: " + e.Message);
                }
            }
        }
    }
