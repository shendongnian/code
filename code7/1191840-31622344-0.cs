    private void GetAllControlsOfType<TControl>(TControl collection, List<TControl> container) where TControl : Control
    {
         foreach(Control control in collection)
         {
              if(control is TControl)
                   container.Add(control);
    
              if(control.HasControls())
                   GetAllControlsOfType<TControl>(control.Controls, container); 
         }
    }
