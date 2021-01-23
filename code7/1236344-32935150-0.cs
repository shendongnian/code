      class MainCharacter
        {
        string characterName;
        int characterGender;
        bool registeredUser;
        int[] playerPosition;
        // Character constructor
        public MainCharacter(string name, int gender, bool registered, int[] location)
        {
            characterName = name;
            characterGender = gender;
            registeredUser = registered;
            playerPosition = location;
        }
        public void drawCharacter(Form form)
        {
            PictureBox playerBox = new PictureBox();
            playerBox.Image = Properties.Resources.mc___main_characters_sprites_by_ssb_fan4ever_d53kkhx;
            playerBox.Width = 28;
            playerBox.Height = 32;
            playerBox.Location = new Point(playerPosition[0], playerPosition[1]);
            playerBox.Visible = true;
            form.Controls.Add(playerBox);
        }
    }
