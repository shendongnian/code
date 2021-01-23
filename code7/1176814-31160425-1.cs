    public MyValue SelectedValue
    {
      get
      {
        if(mycombo.SelectedValue is MyValue)
          return (MyValue)mycombo.SelectedValue);
        else
        {
          MessageBox.Show(string.Format("{0} as new value", mycombo.SelectedText));
          return new MyValue{prop1 = mycombo.SelectedText};
        }
      }
    }
