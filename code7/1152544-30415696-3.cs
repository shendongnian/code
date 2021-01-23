    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    class FlickerForm
    {
      public static void Execute()
      {
        var button  = new Button { Width = 200, Height = 30, Text = "Test" };
        var button2 = new Button { Width = 200, Height = 30, Top = 30, Text = "Test2" };
        var form = new Form { Width = 800, Height = 600, Controls = { button, button2 } };
        form.Load += async (_s, _e) => await Task.WhenAll
         (
          Flicker(button, TimeSpan.FromSeconds(2)),
          Flicker(button2, TimeSpan.FromSeconds(3))
         );
        Application.Run(form);
      }
      static async Task Flicker<T>(T target, TimeSpan period) where T:Control
      {
        for (var isWhite = false; ; isWhite = !isWhite)
        {
          target.BackColor = isWhite ? System.Drawing.Color.White : System.Drawing.Color.Black;
          await Task.Delay(period);
        }
      }
    }
