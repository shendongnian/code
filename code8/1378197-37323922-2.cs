    using System.Linq;
    ...
    foreach(Control c in Controls.OfType<Label>().ToList())
    {
        //check if correct label if you need to
        Controls.Remove(c);
    }
