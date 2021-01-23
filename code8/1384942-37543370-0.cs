    protected void Page_Load(object sender, EventArgs e)
            {
                Table table = this.GetTable();
                form1.Controls.Add(table);
            }
    
            private Table GetTable()
            {
                var table = new Table();
    
                var u1 = new User { CityRank = "1", Name = "Johannesburg", guild = "1", gold = "1", soliders = "1" };
                var u2 = new User { CityRank = "1", Name = "Cape Town", guild = "1", gold = "1", soliders = "2" };
                var u3 = new User { CityRank = "1", Name = "Kiev", guild = "1", gold = "1", soliders = "3" };
    
                var users = new List<User> { u1, u2, u3 };
    
                foreach (User u in users)
                {
                    var row = new TableRow();
                    row.Cells.Add(new TableCell() { Text = u.CityRank });
                    row.Cells.Add(new TableCell() { Text = u.Name });
                    row.Cells.Add(new TableCell() { Text = u.guild });
                    row.Cells.Add(new TableCell() { Text = u.gold });
                    row.Cells.Add(new TableCell() { Text = u.soliders });
    
                    var button = new Button()
                    {
                        ID = u.Name,
                        Text = "Attack"
                    };
    
                    button.Command += AttClick_Clicks;
                    button.CommandArgument = u.Name;
    
                    var buttonCell = new TableCell();
                    buttonCell.Controls.Add(button);
    
                    row.Cells.Add(buttonCell);
    
                    table.Rows.Add(row);
                }
    
                return table;
            }
    
            protected void AttClick_Clicks(object sender, CommandEventArgs e)
            {
                string name = e.CommandArgument as String;
                System.Diagnostics.Debugger.Break();
            }
        }
    
        public class User
        {
            public string CityRank { get; set; }
            public string Name { get; set; }
            public string guild { get; set; }
            public string gold { get; set; }
            public string soliders { get; set; }
        }
