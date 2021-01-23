    public Constraint XConstaint
    {
      get => _xConstaint;
      set { SetFieldValue(ref _xConstaint, value, nameof(XConstaint)); }
    }
    
    public override void OnAppearing()
    {
      base.OnAppearing();
      XConstaint = Constraint.RelativeToParent((parent) => { return parent.Width - 128; });
    }
