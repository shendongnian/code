    Entity updatedEntity = _service.Retrieve(entity.LogicalName,entity.Id,new ColumnSet("new_cr‌​ea‌​teticket","title"))
    if (updatedEntity.GetAttribute‌​‌​Value<bool>("new_cr‌​ea‌​teticket") == true)
      {
         Entity ticket = new Entity("new_troubleticket");
         ticket["new_subject"] = updatedEntity.GetAttributeValue<String>("title");
         Guid ticketid = service.Create(ticket);
    updatedEntity["new_troubleticketid"] = new EntityReference("new_troubleticket", ticketid);
        updatedEntity["new_createticket"] = false;
      }
