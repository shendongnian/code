    Observable.FromEvent<MyDelegate, MyArgs>(
      converter => new MyDelegate(
                      (id, price, amount) => converter(new MyArgs { 
                                                            RequestId = id, 
                                                            Price = price, 
                                                            Amount = amount
                                                           })
                   ),
      handler => MyEvent += handler,
      handler => MyEvent -= handler);
