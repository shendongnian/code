    Delivery delivery = db.Deliverys.Find(model.ID);
    // Map the view model properties to the data model
    delivery.DriverID = model.DriverID;
    delivery.Dispatched_Date = model.Dispatched_Date;
    delivery.Dispatched_Time = model.Dispatched_Time;
    delivery.Delivered_Date = model.Delivered_Date;
    delivery.Delivered_Time = model.Delivered_Time;
    delivery.Delayed_Date = model.Delayed_Date;
    delivery.Delayed_Time = model.Delayed_Time;
    delivery.Comment = model.Comment;
    //where is this?
    delivery.Status = model.Status;//do a mapping from int or string if you change VM like i suggested
