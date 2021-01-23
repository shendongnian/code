    public class ControllerFactory
    {
      public static IController GetController (IAnimal animalToControl)
      {
        if (animalToControl is Turtle) { return new TurtleController(); }
        if (animalToControl is Sheep) { return new SheepController(); }
    
        // default
        return new Controller();
      }
    }
