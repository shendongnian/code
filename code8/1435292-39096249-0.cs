    public void PrintNodes(LinkedList<Transactions> values)
        {
            if (values != null && values.Count > 0)
            {
                int accountNumber = 1000001;
                StringBuilder builder = new StringBuilder();
                builder.Append($"Transaction Details for Account No. {accountNumber}");
                builder.Append(Environment.NewLine);
                builder.Append("Date\t\tDescription\t\tDebitCredit\t\tAmount");
                builder.Append(Environment.NewLine);
                foreach (Transactions t in values)
                {
                    builder.Append($"{t.Date}\t\t{t.Description}\t\t{t.DebitCard}\t\t{t.Amount}");
                    builder.Append(Environment.NewLine);
                }
                txtOutput.Text += builder.ToString();
            }
            else
            {
                txtOutput.Text = "The list is empty!";
            }
        }
