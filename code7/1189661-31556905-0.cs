    class MyMiddleFormClass : Form
    {
         public MyMiddleFormClass()
         {
              this.OnLoad += OnLoadHandler;
         }
         private void OnLoadHandler(object o, EventArgs e)
         {
              foreach(var lbl in this.Controls.OfType<Label>())
                  lbl.BackColor = Color.DarkRed;
         }
    }
