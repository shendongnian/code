               RichTextBox SMStext = new RichTextBox();
               
                TableLayoutPanel pnl1 = new TableLayoutPanel();
                pnl1.RowStyles.Clear();
                pnl1.ColumnStyles.Clear();
                pnl1.RowCount += 2;
                pnl1.ColumnCount += 1;
                pnl1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0F));
                pnl1.RowStyles.Add(new RowStyle(SizeType.Percent,80.0F));
                pnl1.RowStyles.Add(new RowStyle(SizeType.Percent,20.0F));
                pnl1.Controls.Add(SMStext,0,0);
                SMStext.Dock = DockStyle.Fill;
                Button SMSsend = new Button();
                SMSsend.Text = "Send SMS to ";
                this.Controls.Add(pnl1);
                pnl1.Dock = DockStyle.Fill;
                pnl1.Controls.Add(SMSsend,0,1);
                SMSsend.Dock = DockStyle.Fill;
               SMSsend.Margin = new Padding(10);
