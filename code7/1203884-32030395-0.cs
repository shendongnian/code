    lock (this._printStatusLast)
    {
        // make a query to OS
        // TODO: make the printers exclude from counting in below query (defined by admin)
        ManagementObjectCollection pmoc = new ManagementObjectSearcher("SELECT Name, NotReadyErrors, OutofPaperErrors, TotalJobsPrinted, TotalPagesPrinted FROM Win32_PerfRawData_Spooler_PrintQueue").Get();
        Dictionary<String, PrintDetail> phs = new Dictionary<string, PrintDetail>();
        foreach (ManagementObject mo in pmoc)
        {
            // do not count everything twice!! (this is needed to for future developments on excluding printers from getting count)
            if (mo["name"].ToString().ToLower() == "_total") continue;
            PrintDetail pd = new PrintDetail();
            foreach (PropertyData prop in mo.Properties)
            {
                if (prop.Name.ToLower() == "name") continue;
                pd[prop.Name] = (UInt32)prop.Value;
            }
            phs.Add(mo["name"].ToString(), pd);
        }
        UInt32 count = 0;
        // foreach category
        foreach (var _key in phs.Keys.ToArray<String>())
        {
            // do not count if there where any errors
            if (phs[_key].HasError) continue;
            count += phs[_key].TotalPagesPrinted;
        }
        this.txtPrint.Text = count.ToString();
        this._printStatusLast = new Dictionary<string, PrintDetail>(phs);
    }
