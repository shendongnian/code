        private void pgConfig_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
          GridItem giSelected = e.NewSelection;
          if ((giSelected != null) && (giSelected.PropertyDescriptor != null))
          {
            string sDescription = GetCurrentPropertyDescription(giSelected.PropertyDescriptor.Name);
            if ((sDescription != null) && (sDescription != giSelected.PropertyDescriptor.Description))
            {
              MethodInfo miSetStatusBox = pgConfig.GetType().GetMethod("SetStatusBox", BindingFlags.NonPublic | BindingFlags.Instance);
              if (miSetStatusBox != null)
                miSetStatusBox.Invoke(pgConfig, new object[] { giSelected.PropertyDescriptor.DisplayName, sDescription });
            }
          }
        }
