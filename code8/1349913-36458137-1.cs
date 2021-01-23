    string Old_Date = "Test SomeName(3/12/10)";
    string No_Date = "";
    int Date_Pos = 0;
    Date_Pos = Old_Date.IndexOf("(");
    No_Date = Old_Date.Remove(Date_Pos).Trim();
    MessageBox.Show(No_Date, "Your Updated String", MessageBoxButton.OK);
