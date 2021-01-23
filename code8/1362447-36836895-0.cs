    public class MainWindow {
      // Declaraion is OK, calling method _masina[0].Load(1, 'x') - is not
      private Masina[] _masina = new Masina[10];
      
      // constructor is the place you're supposed to put complex initialization to
      public MainWindow() {
        // You can call the method in the constructor
        SomeFunction(_masina);
      }
      
      public static void SomeFunction(Masina[] masina) {
        // validate arguments in the public methods
        if (null == masina)
          throw new ArgumentNullException("masina");
    
        // do not use magic numbers (10), but actual parameters (masina.Length)
        for (int i = 0; i < masina.Length; ++i)
          masina[i].Load(i, 'x');
        // hiding all exceptions - catch {} - is very bad idea
      }
    }
