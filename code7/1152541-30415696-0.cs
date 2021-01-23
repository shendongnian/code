    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
      class FlickerForm
      {
        public static void Execute()
        {
          var button = new Button { Width = 200, Height = 30, Text = "Test" };
          var form = new Form { Width = 800, Height = 600, Controls = {button} };
    
          form.Load += async(_s, _e) => await Flicker(button);
    
          Application.Run(form);
        }
    
        static async Task Flicker<T>(T target) where T:Control
        {
          for (var isWhite = true; ; isWhite = !isWhite)
          {
            target.BackColor = isWhite 
                ? System.Drawing.Color.White 
                : System.Drawing.Color.Black;
            await Task.Delay(TimeSpan.FromSeconds(2));
          }
        }
      }
