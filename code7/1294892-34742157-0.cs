        try
        {
            _sessID = _session[0].Trim();
            _servName = _session[1];
        }
        catch (Exception exp)
        {
            // MessageBox.Show(exp.Message);
        }
