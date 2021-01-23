    public class ColourViewModel :INotifyPropertyChanged
    {
      private Color _colour;
      public Color Colour 
      {
        get { return _colour; }
        set
        {
          _colour = value;
          // raise change notification
        }
      }
    }
    private void ChangeColorCommandExecute(object o)
    {
        ColourViewModel cvm = o as ColourViewModel;
        if (cvm != null)
        {
           Views.DialogViews.ColorPickerDialog cpd = new Views.DialogViews.ColorPickerDialog(cvm.Colour);
          cpd.ShowDialog();
    
          if(cpd.DialogResult == Views.DialogViews.ColorPickerDialog.DialogResults.Ok)
          {
            cvm.Colour = cpd.SelectedColor;
          }
        }
    }
