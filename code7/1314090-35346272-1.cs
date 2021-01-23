    public void PerformClick() {
      if (CanSelect) {
         bool validatedControlAllowsFocusChange;
         bool validate = ValidateActiveControl(out validatedControlAllowsFocusChange);
         if (!ValidationCancelled && (validate || validatedControlAllowsFocusChange))
         {
           //Paint in raised state...
           ResetFlagsandPaint();
           OnClick(EventArgs.Empty);
         }
      }
    }
