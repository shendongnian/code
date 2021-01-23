    private void RemoveItemByName<T>(Panel panel, string name) 
      where T : System.Windows.Control
    {
        foreach (T item in panel.Controls.OfType<T>().ToList().Where(
         item => item.Name == name))
              panel.Controls.Remove(item);
    }
