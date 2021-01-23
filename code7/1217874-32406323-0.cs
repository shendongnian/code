    public class PanelEx : Panel {
      protected override Point ScrollToControl(Control activeControl) {
        return this.DisplayRectangle.Location;
      }
    }
