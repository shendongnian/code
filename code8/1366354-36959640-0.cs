    string text = "Username: hello this is a chat message";
    // delete the first line when after 10 lines
    if (ChatText.Lines.Length >= 10)
    {
        ChatText.SelectionStart = 0; // set SelectionStart to the beginning of chat text (RichTextBox)
        ChatText.SelectionLength = ChatText.Text.IndexOf("\n", 0) + 1; // select the first line
        ChatText.SelectedText = ""; // replace by an empty string
        ChatText.SelectionStart = ChatText.Text.Length; // set SelectionStart to text end to make SelectionFont work for appended text
    }
    // split the string in chatstr[0] = username, chatstr[1] = message
    string[] chatstr = text.Split(new string[] { ": " }, 2, StringSplitOptions.None);
    // make the username bold
    ChatText.SelectionFont = new Font(ChatText.Font, FontStyle.Bold);
    ChatText.AppendText(chatstr[0] + ": ");
    // make the message regular
    ChatText.SelectionFont = new Font(ChatText.Font, FontStyle.Regular);
    ChatText.AppendText(chatstr[1] + Environment.NewLine);
    ChatText.ScrollToCaret();
