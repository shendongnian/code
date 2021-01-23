    public class MainActivity : FormsApplicationActivity
    {
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (this.ActionBar.Title == "YourMainMenuTitle")
            {
                if (keyCode == Keycode.Back && e.RepeatCount == 0)
                {
                    MoveTaskToBack(true);
                    return true;
                }
            }
            return base.OnKeyDown(keyCode, e);
        }
        ...
    }
