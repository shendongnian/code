    // your form class declared here
    public partial class Form1 : Form
    {
        // code omitted here
    }
    // declare the extension method in this extension class
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control c, Action<Control> action)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
    }
