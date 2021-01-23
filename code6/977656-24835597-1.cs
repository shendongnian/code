    private void submit_Click(object sender, EventArgs e){
        clickCount++;
        // Other code that happens on a click
        if (clickCount == 10){  // 10th click show main menu
            mainMenu.Show();
            this.Hide();
        }
    }
