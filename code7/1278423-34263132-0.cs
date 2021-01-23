    Control prevControl = null;
    foreach (Control control in myFlowLayoutPanel.Controls)
    {
         if (prevControl == null)
         {          
              // line break
         }
         else if (prevControl.Left > control.Left)
         {
              // line break
         }
         prevControl = control;
    }
