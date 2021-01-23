    // Probably, you'd rather return T (created control), not void 
    public void CreateControl<T>() 
      where T: Control, new() {
    
      this.Controls.Add(new T());
    }
  ...
 
    CreateControl<Button>();
