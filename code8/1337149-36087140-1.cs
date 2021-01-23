    using (FontEditor fe = new FontEditor(chart1.Titles[0].Font))
    {
        if (DialogResult.OK == fe.ShowDialog())
        {
            chart1.Titles[0].Font = fe.UpdatedFont;
        }
    }
