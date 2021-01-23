    public class MyButton: Button
    {
         protected override void OnClick(EventArgs e)
         {
              if (validate())
              {
                 base.OnClick(e);
              }
              //Do nothing or whatever
         }
    }
