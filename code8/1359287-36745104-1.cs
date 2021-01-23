    public partial class Form2 : Form
    {
        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        private void OnSubmitButtonClick(object sender, EventArgs e)
        {
            var args = new ItemAddedEventArgs(
                issue: textBoxIssue.Text,
                comment: textBoxComment.Text);
            ItemAdded(this, args);
        }
    }
