    public static OrderModel ConvertToModel(Order entity)
    {
        if (entity == null) return null;
        OrderModel model = new OrderModel
        {
            ContactId = entity.contactId,
            OrderId = entity.orderId,
        }
        return model;
    }
