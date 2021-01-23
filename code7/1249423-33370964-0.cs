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
        //This is where the logic of whether you want to hide or show the combobox should be. 
        static void HideComboBox(ComboBox cbox, bool val)
        {
          if (val)
          {
            //Check if the combobox is either null or empty
            if (cbox.Items == null || cbox.Items.Count < 1)
              cbox.Visibility = Visibility.Collapsed;
            else
            {
              bool hide = true;
              //Check if all the items are not visible. If an item is visible we won't hide the combobox. 
              foreach (ComboBoxItem i in cbox.Items)
              {
                if (i.Visibility == Visibility.Visible)
                {
                  hide = false;
                  break;
                }
              }
    
              if (!hide)
                cbox.Visibility = Visibility.Visible;
              else
                cbox.Visibility = Visibility.Collapsed;
            }
          }
        }
      }
