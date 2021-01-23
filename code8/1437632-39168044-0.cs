    Dictionary<string, TextBox> textboxes = new Dictionary<string, TextBox>();
    for (int i = 0; i < N; i++)
    {
        foreach (object o in t) 
        {
            TextBox a = new TextBox();
            .....
            NumericUpDown note = new NumericUpDown();
            note.Name = "Note" + i.ToString();
            ......
		
            textboxes.Add(note.Name, a);
        }
    }
 
    foreach (NumericUpDown ctlNumeric in panel.Controls.OfType<NumericUpDown>())
    {
        var value = ctlNumeric.Value;
        int number = Decimal.ToInt32(value);
        TextBox tb = textboxes[ctrlNumeric.Name];
        String text = tb.Text;
        .........
    }
