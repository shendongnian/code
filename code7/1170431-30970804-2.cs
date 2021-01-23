    public static void Focus<T>(Form parent) where T : System.Windows.Forms.Form
    {
        bool isOpen = false;
        foreach (var f in Application.OpenForms)
        {
            if (f is T)
            {
                isOpen = true;
                (f as Form).Focus();
                break;    
            }
         }
         if (!isOpen)
         {
             T newForm = Activator.CreateInstance<T>();
             newForm.MdiParent = parent;
             newForm.Show();
         }
    }
