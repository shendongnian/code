           var qe = new QueryExpression
            {
                EntityName = "invoice",
                ColumnSet = new ColumnSet("salesorderid", "invoicenumber"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("salesorderid", ConditionOperator.Equal, orderId)
                    }
                }
            };
           var ec = service.RetrieveMultiple(qe);
           var orderName = generateInvoiceID(service, orderId);
            foreach (var entity in ec.Entities)
            {
                var invoice = new Entity("invoice") { Id = entity.Id };
                invoice.Attributes.Add("invoicenumber", Convert.ToInt32(orderName) + 01);
                service.Update(invoice); //call the update method.
            }
