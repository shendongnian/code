    Form MainForm
    {
        // Button to open the smileys window. Note you give "this" (MainForm)
        // to the EmoteForm so it can call this object's public functions.
        private void btnOpenEmoticons_Click(object sender, EventArgs e)
        {
            // open the smileys window, giving this as parameter
            EmoteForm emoticons = new EmoteForm(this);
            emoticons.Show();
        }
        // Delegates are always needed to access user interface stuff from external
        // sources, since they generally run on different threads.
        private delegate void InsertEmoticonDelegate(RichTextBox rtb, String emotCode);
        //The function you call from the emoticons form
        public void InsertEmoticon(String emotCode)
        {
            // Invoke and Delegate are needed for thread safety:
            // you're asking this nicely, not stuffing it in there.
            chatTextBox.Invoke(new InsertEmoticonDelegate(AddEmoticon), chatTextBox, emotCode));
        }
        // needs to match the Delegate so it can be called with Invoke
        private void AddEmoticon(RichTextBox rtb, String emotCode)
        {
            // perform code to add the image defined by the "emotCode" string
            // into the rich text box "rtb".
        }
    }
