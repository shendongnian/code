        private void copyControl(Control sourceControl, Control targetControl)
        {
            // make sure these are the same
            if (sourceControl.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }
            foreach (PropertyInfo sourceProperty in sourceControl.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty))
            {
                object newValue = sourceProperty.GetValue(sourceControl, null);
                sourceProperty.SetValue(targetControl, newValue, null);
            }
        }
