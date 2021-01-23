                for (int i = 0; i < membersFiles.Length; i++)
            {
                searchForShooterComboBox.Items.Add(membersFiles[i].Replace(".txt", "").Replace(@"C:\Users\Nicolai\Desktop\skytter\", "").Replace("-", " "));
                memberFileNames.Add(membersFiles[i].Replace(".txt", "").Replace(@"C:\Users\Nicolai\Desktop\skytter\", "").Replace("-", " "));
            }
