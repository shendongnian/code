        private void CheckBox_NumericState(object sender, EventArgs e)
        {
    
        // disable everything
        DisableNumericUpDowns();
    
        // see if more than one checkbox is checked:
        var numChecked = _checkBoxs.Count((cb) => cb.Checked);
    
        // enable things if more than one item is checked:
        if (numChecked <= 1) return;
    
        // find the smallest and enable its max:
        var smallest = -1;
        for (var i = 0; i < _checkBoxs.Length; i++)
        {
            if (!_checkBoxs[i].Checked) continue;
            if (_maximumsNumericUpDowns[i] != null)
            {
                _maximumsNumericUpDowns[i].Enabled = true;
            }
            smallest = i;
            break;
        }
    
        // find the largest and enable its min:
        var largest = -1;
        for (var i = _checkBoxs.Length - 1; i >= 0; i--)
        {
            if (!_checkBoxs[i].Checked) continue;
            if (_minimumsNumericUpDowns[i] != null)
            {
                _minimumsNumericUpDowns[i].Enabled = true;
            }
            largest = i;
            break;
        }
    
        // enable both for everything between smallest and largest:
        var tempVar = largest - 1;
        for (var i = (smallest + 1); i <= tempVar; i++)
        {
            if (!_checkBoxs[i].Checked) continue;
            if (_minimumsNumericUpDowns[i] != null)
            {
                _minimumsNumericUpDowns[i].Enabled = true;
            }
            if (_maximumsNumericUpDowns[i] != null)
            {
                _maximumsNumericUpDowns[i].Enabled = true;
            }
        }
        }
