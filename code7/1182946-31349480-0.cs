            string on1 = "Music";
            string on2 = "Song Name";
            switch (on1) {
                case "Music":
                    switch (on2)
                    {
                        case "Song Name":
                            System.Windows.Forms.MessageBox.Show("Playing Song Name");
                            break;
                        case "Song 2":
                            System.Windows.Forms.MessageBox.Show("Playing Song 2");
                            break;
                    }
                    break;
            }
