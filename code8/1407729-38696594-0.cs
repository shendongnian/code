    public void UpdateOrderStatus(string orderIncrementId, string newStatus, string comment = "")
    {
        // Init service with uri
        var service = new MagentoSoap.MagentoService();
        // Login - username and password (soap api key) of the soap user
        string sessionId = service.login(Username, Password);
        // Update order status
        service.salesOrderAddComment(sessionId, orderIncrementId, newStatus, comment, 1, true);
    }
