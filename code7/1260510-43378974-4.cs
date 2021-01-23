    private void DisableNumericUpDowns()
    {
        // disable everything:
        foreach (var n in _minimumsNumericUpDowns)
        {
            if (n != null)
                n.Enabled = false;
        }
        foreach (var n in _maximumsNumericUpDowns)
        {
            if (n != null)
                n.Enabled = false;
        }
    }
