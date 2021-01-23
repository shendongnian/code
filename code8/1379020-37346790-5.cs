    foreach(Checkbox c in Control.Controls)
    {
        c.CheckedChanged += (s,e)=>
        {
            var cb = s as Checkbox;
            if(cb.Checked)
                Order.AddSpecialInstruction(cb.Text);
            else
                Order.RemoveSpecialInstruction(cb.Text);
        }
    }
