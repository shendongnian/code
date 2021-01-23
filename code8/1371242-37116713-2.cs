    public static string CreateErrorMessage(CheckInput status)
    {
        StringBuilder result = new StringBuilder("Please correct the following issues:\n");
        if ((status & CheckInput.No_First_Name) != 0)
            result.AppendLine("Missing first name.");
        if ((status & CheckInput.No_Last_Name) != 0)
            result.AppendLine("Missing last name.");
        if ((status & CheckInput.No_Password) != 0)
            result.AppendLine("Missing password.");
        if ((status & CheckInput.Wrong_Password) != 0)
            result.AppendLine("Invalid password");
        return result.ToString();
    }
