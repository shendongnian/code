    // retrieves document name
            string[]customValues = _ruleCustomValue.Split('|');
            // retrieves emails
            string[] emails = customValues[1].Split(';');
            foreach (string email in emails)
            {
                if (!email.Contains("@"))
                {
                    throw new System.InvalidOperationException("Invalid Email adress,");
                }
            }
