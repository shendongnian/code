    public class MovementController : Controller {
        public MovementController(MotorController motorController) {
            //...
        }
    }
    public interface IMotorController {
        //...
    }
    public class MotorController : IMotorController {
        //...
    }
