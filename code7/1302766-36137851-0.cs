    IEnumerable InotifyDataErrorInfo.GetErrors(string propertyName)
        {
            if (UserNames.Length == 0)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    return "Some credentials component is wrong.";
                }
                else if (propertyName == "UserNames")
                {
                    return "User name is required field.";
               }
            }
        }
