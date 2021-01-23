    double output = 0;
    if (double.TryParse(textBoxSample1.Text, out output))
    {
        oleDBCommand.Parameters.Add(new OleDbParameter("@Sample1Vol", output));
    }
    else
    {
        oleDBCommand.Parameters.Add(new OleDbParameter("@Sample1Vol", DBNull.Value));
    }
