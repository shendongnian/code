    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    private void MainMenu_Load(object sender, EventArgs e)
        {
    
            UserslistView.View = View.Details;
                UserslistView.GridLines = true;
                UserslistView.Sorting = SortOrder.Descending;
                UserslistView.Columns.Add("Active", 80);
                UserslistView.Columns.Add("username", 120);
                UserslistView.Columns.Add("Last Logon", 120);
    
                UserslistView.Items.Clear();
    
    
                var doc = XDocument.Parse(Properties.Resources.Users);
                var output = from x in doc.Root.Elements("user")
                             select new ListViewItem(new []
                             {
                                 x.Element("USERID").Value,
                                 x.Element("username").Value,
                                 x.Element("lastlogon").Value
    
                             });
                UserslistView.Items.AddRange(output.ToArray());
    
            }
        }
