    var sagePay = new SagePayIntegration();   
    var ordersManager = OrdersManager.GetManager();
        
    var query = sagePay.ConvertSagePayMessageToNameValueCollection(ProtocolMessage.DIRECT_PAYMENT_RESULT, typeof(IDirectPaymentResult), result, ProtocolVersion.V_223);
    
    // Required Sitefinity fields to trigger HandleOffsiteNotification in IOffsitePaymentProcessorProvider
    query.Add("invoice", orderNumber.ToString());
    query.Add("provider", ordersManager.Provider.Name);
    
    var queryString = sagePay.BuildQueryString(query);
    // Post 3d secure details to this site simulate an offsite payment processor response
    sagePay.ProcessWebRequestToSagePay(notificationUrl, queryString);
