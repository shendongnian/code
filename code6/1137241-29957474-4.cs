    var dates = this.Controls.Cast<Control>()
                             .OfType<DateTimePicker>()
                             .Select(dtp => dtp.Value.ToString("yyyy,M,d,H,m,s"));
    var bools = this.Controls.Cast<Control>()
                             .OfType<CheckBox>()
                             .Select(cb => Convert.ToInt32(cb.Checked).ToString());
    var str = String.Join(",", dates.Concat(bools).ToArray());
