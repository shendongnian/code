            private void AddUserProperty(Outlook.MailItem mail)
        {
            Outlook.UserProperties mailUserProperties = null;
            Outlook.UserProperty mailUserProperty = null;
            try
            {
                mailUserProperties = mail.UserProperties;
                mailUserProperty = mailUserProperties.Add("MailItemNrProperty", Outlook.OlUserPropertyType.olText, false, 1);
                // Where 1 is OlFormatText (introduced in Outlook 2007)
                mail.UserProperties["MailItemNumber"].Value = "Any value as string...";
                mail.Save();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (mailUserProperty != null) Marshal.ReleaseComObject(mailUserProperty);
                if (mailUserProperties != null) Marshal.ReleaseComObject(mailUserProperties);
            }
        }
