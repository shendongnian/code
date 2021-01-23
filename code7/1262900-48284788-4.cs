    // last processed text
    string lastProcessed;
    private async void textBox1_TextChanged(object sender, EventArgs e) {
        // clear last processed text if user deleted all text
        if (string.IsNullOrEmpty(textBox1.Text)) lastProcessed = null;
        // this inner method checks if user is still typing
        async Task<bool> UserKeepsTyping() {
            string txt = textBox1.Text;   // remember text
            await Task.Delay(500);        // wait some
            return txt != textBox1.Text;  // return that text chaged or not
        }
        if (await UserKeepsTyping() || textBox1.Text == lastProcessed) return;
        // save the text you process, and do your stuff
        lastProcessed = textBox1.Text;   
    }
