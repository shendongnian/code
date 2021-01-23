    public class Form1 : Form
    {
        // ...
        
        private static IEnumerable<Button> GetAllButtons(Control control)
        {
            return control.Controls.OfType<Button>().Concat(control.Controls.OfType<Control>().SelectMany(GetAllButtons));
        }
        private void DoSomethingWithAllButtons()
        {
            foreach(var button in GetAllButtons(this))
            { // do something with button }
        }
    }
