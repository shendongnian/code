    static void g_detected(object sender, PinStatusEventArgs e) {
      edges += 1;
      switch (edges % 2) {
        case 1:
          break;
        case 0:
          if (weatherView.Visible) {
            weatherView.Visible = false;
            stockView.Visible = true;
          } else if (!weatherView.Visible) {
            weatherView.Visible = true;
            stockView.Visible = false;
          }
          break;
        default:
          //Will never hit, just to handle general coding conventions.
          break;
      }
    }
