    foreach (Control c in this.Controls)
    {
         if (c.Name == "Name of button to delete")
         {
               this.Controls.Remove(c);
               break;
         }
    }
