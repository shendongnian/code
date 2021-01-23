    class Account
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Number { get; set; }
            public string PreferredContact { get; set; }
        }
                accountComboBox.Items.AddRange(
                    lines.Select(line => Regex.Split(line, "[#\\d#]")).Select(data => new Account
                    {
                        FirstName = data[0],
                        LastName = data[1],
                        Email = data[2],
                        Number = data[3],
                        PreferredContact = data[4]
                    }).Select(item => string.Format("{0},{1}", item.LastName, item.FirstName)).ToArray()
                    );
