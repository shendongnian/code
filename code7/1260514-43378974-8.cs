        // Light
        if (cbLight.Checked)
        {
            if (nLightMin.Enabled == false && nLightMax.Enabled == false)
            {
                _structCategoryType = Light;
                CheckStructureSheets();
            }
            else
            {
                if (nLightMin.Enabled && nLightMin.Value > 0)
                {
        if (nXLightMax.Enabled && nLightMin.Enabled && nLightMax.Enabled == false)
        {
            _dMin = nLightMin.Value;
            _structCategoryType = Light;
           CheckStructureSheets();
        }
        else
        {
            if (nLightMax.Value > 0)
           {
                _dMin = nLightMin.Value;
                _dMax = nLightMax.Value;
                _structCategoryType = Light;
                CheckStructureSheets();
            }
            else
            {
                MessageBox.Show(@"Light Max cannot be zero (0)");
                return;
            }
    }
            }
            else if (nLightMin.Enabled == false && nLightMax.Enabled)
            {
        if (nLightMax.Value > 0)
        {
        _dMax = nLightMax.Value;
        _structCategoryType = Light;
        CheckStructureSheets();
        }
        else
       {
        MessageBox.Show(@"Light Max cannot be zero (0)");
        }
                }
                else
                {
        MessageBox.Show(@"Light Min cannot be zero (0)");
        return;
                }
            }
        }
