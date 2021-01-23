    // on the class level:
    private int _LabelIndex;
    // on the method you want to use for changing the backColor of a lable:
    // you might want to change the backcolor of all other lables back to SystemColors.Control. 
    // if that is the case, you can do something like this:
    this.tableLayoutPanel1.Controls.OfType<Label>().ToList().ForEach(c => c.BackColor = SystemColors.Control);
    _LabelIndex = los.Next(0, this.tableLayoutPanel1.Controls.Count);
    this.tableLayoutPanel1.Controls[labelIndex].BackColor = Color.Red;
