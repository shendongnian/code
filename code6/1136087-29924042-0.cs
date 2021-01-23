    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (myFile.FileBytes.Length > 204800)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;       
        }
    }
