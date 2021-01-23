    select service_id,  delivery_id,  price_increase 
    from table order by service_id,  delivery_id 
    
    int? serviceID = null;
    ServicePricing sp; 
    List<ServicePricing> sps; 
    while (rdr.Read())
    {
       if(rdr.GetInt(0) <> serviceID)
       {
          if(sp != null) 
            sps.Add(sp);
          serviceID = rdr.GetInt(0);
          sp = new ServicePricing(serviceID); 
       }
       sp.DeliveryPricings.Add(new DeliveryPricing(rdr.GetInt(1), rdr.GetDecimal(2));
    }
    sps.Add(sp);
