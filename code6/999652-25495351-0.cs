    public class GameVM : INotifyPropertyChanged {
      // Title and other properties
      private Canvas _myUICanvas;
      public Canvas myUICanvas
      {
        get {
          _myUICanvas = Draw();
          return _myUICanvas;
        }
        set {
          // this is never called
          _myUICanvas = value;
        }
      }
      public Canvas Draw() {
        Canvas newCanvas = new Canvas();
        Ellispe stone = new Ellipse();
        // [...] Add Fill, Strock, Width, Height properties and set Canvas.Left and Canvas.Top...
        newCanvas.Children.Add(stone);
        return newCanvas;
      }
    }
