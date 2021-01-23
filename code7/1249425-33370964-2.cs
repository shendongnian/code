    public class ComboBoxExt
      {
        public static bool GetHideOnEmpty(DependencyObject obj)
        {
          return (bool)obj.GetValue(HideOnEmptyProperty);
        }
    
        public static void SetHideOnEmpty(DependencyObject obj, bool value)
        {
          obj.SetValue(HideOnEmptyProperty, value);
        }
    
        public static readonly DependencyProperty HideOnEmptyProperty =
            DependencyProperty.RegisterAttached("HideOnEmpty", typeof(bool), typeof(ComboBoxExt), new UIPropertyMetadata(false, HideOnEmptyChanged));
    
        private static void HideOnEmptyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          var cbox = d as ComboBox;
    
          if (cbox == null)
            return;
    
          HideComboBox(cbox, (bool)e.NewValue);
        }
        //This is where we check if all the items are not visible
        static void HideComboBox(ComboBox cbox, bool val)
        {
          //First, we have to know if the HideOnEmpty property is set to true. 
          if (val)
          {
            //Check if the combobox is either null or empty
            if (cbox.Items == null || cbox.Items.Count < 1)
              cbox.Visibility = Visibility.Collapsed; //Hide the combobox
            else
            {
              bool hide = true;
              //Check if all the items are not visible.  
              foreach (ComboBoxItem i in cbox.Items)
              {
                if (i.Visibility == Visibility.Visible)
                {
                  hide = false;
                  break;
                }
              }
    
              //If one or more items above is visible we won't hide the combobox.
              if (!hide)
                cbox.Visibility = Visibility.Visible;
              else
                cbox.Visibility = Visibility.Collapsed;
            }
          }
        }
      }
