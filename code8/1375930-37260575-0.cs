    public class Controller
    {
       public void Process(Animal a)
       {
          if(a.GetType() == typeof(Turtle)
          {
             ((Turtle)a).YourMethod();
          }
          else
          {
            a.Eat();
            a.MakeNoise();
            a.Go;
           }
       }
    }
