    private void submit_Click(object sender, EventArgs e){
        clickCount++;
        // Other code that happens on a click
        if (clickCount == 10){
            mainMenu.Show();
            this.Hide();
        }
    }
