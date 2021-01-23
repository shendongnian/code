    private void AddClassesToList(object o)
    {
        this.statusValue.Text = "Searching...";
        try
        {
            // Perform WMI object query on 
            // selected namespace.
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(
                new ManagementScope(
                namespaceValue.Text),
                new WqlObjectQuery(
                "select * from meta_class"),
                null);
            foreach (ManagementClass wmiClass in
                searcher.Get())
            {
                this.classList.Items.Add(
                    wmiClass["__CLASS"].ToString());
                count++;
            }
            this.statusValue.Text =
                count + " classes found.";
        }
        catch (ManagementException ex)
        {
            this.statusValue.Text = ex.Message;
        }
    }
