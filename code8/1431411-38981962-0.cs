        protected void CustomValidator_ServerValidate(object source,
                                                       ServerValidateEventArgs args)
        {
            if (!String.IsNullOrWhiteSpace(billingAddress.Text) && 
                      String.IsNullOrWhiteSpace(billingCity.Text) &&
                            ext...) 
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
