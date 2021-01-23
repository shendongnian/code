    oleDbCmd.CommandText = "insert into tbl_flight(fld_PassengerName, fld_destination, fld_class, fld_date, fld_time) values(@PassengerName, @Destination, @Class, @Date, @Time)";
    List<OleDbParameter> args = new List<OleDbParameter>();
    args.Add(new OleDbParameter("@PassengerName", textBox1.Text));
    args.Add(new OleDbParameter("@Destination", textBox2.Text));
    args.Add(new OleDbParameter("@Class", comboBox1.SelectedItem));
    args.Add(new OleDbParameter("@Date", comboBox2.SelectedItem));
    args.Add(new OleDbParameter("@Time", dateTimePicker1.Value));
    oleDbCmd.Parameters.Add(args.ToArray());
