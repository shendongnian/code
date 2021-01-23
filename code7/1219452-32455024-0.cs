    foreach(var customer in customers)
    {
        if(customer.Id == 0) { session.Save(customer); }
        else { session.Update(customer); }
    }
