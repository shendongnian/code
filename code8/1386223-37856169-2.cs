    abstract class BaseMessage {
        
    }
    [Message("/api/commands/CreateOrder", "This command creates new order")]
    [RespondsWith(typeof(CreateOrderResponse))]
    class CreateOrderCommand : BaseMessage {
    }
    class CreateOrderResponse {   
        public long OrderID { get; set; }
        public string Description { get; set; }
    }
