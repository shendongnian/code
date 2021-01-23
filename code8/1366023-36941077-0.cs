    public interface IOrderService
    {
       //SomeOrderFunction()
       IPlanService planService;
    }
    ....
    public class PlanService: IPlanService
    {
       private readonly IOrderService _orderService;
       public PlanService(IOrderService orderService)
       {
          _orderService = orderService;
          _orderService.planService = this;
       }
    }
