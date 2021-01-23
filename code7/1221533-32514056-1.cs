    Mapper.Initialize(cfg =>
            {
                cfg .CreateMap<Order, OrderDto>()
                  .Include<OnlineOrder, OnlineOrderDto>()
                  .Include<MailOrder, MailOrderDto>();
                  cfg.CreateMap<OnlineOrder, OrderDto>();
                  cfg.CreateMap<MailOrder, OrderDto>();
            });
