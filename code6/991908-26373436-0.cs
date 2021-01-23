        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutomationElement aeDesktop = AutomationLibrary.GetDesktop();
                AutomationElement aeChrome =
                    AutomationLibrary.GetAutomationElement(
                        "Gmail - Verify your Disqus.com account - Google Chrome", aeDesktop);
                List<AutomationElement> aeCollection = AutomationLibrary.GetAllAutomationElements(aeChrome);
                foreach (AutomationElement ae in aeCollection)
                {
                    System.Diagnostics.Debug.WriteLine(ae.Current.Name);
                    if (ae.Current.Name == "Save As")
                    {
                        List<AutomationElement> aeCollection2 = AutomationLibrary.GetAllAutomationElements(ae);
                        foreach (AutomationElement ae2 in aeCollection2)
                        {
                            System.Diagnostics.Debug.WriteLine(ae2.Current.Name);
                        }
                        return;
                    }
                }
            }
            catch (UnableToFindAutomationElementException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
