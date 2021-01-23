    using System.Linq;
    ...
    foreach(Control c in Controls.ToList())
    {
        if(c is label)//add more checks here
            Controls.Remove(c);
    }
