    public class YourClass : Form
    {
        private Word.Application word = new Word.Application {Visible = false};
        private Word.Document doc;
        // where did you get this file name?
        private string fileName;
        private void Count()
        {
            // as you mentioned, you open your word document here
            doc = word.Documents.Open(fileName, ReadOnly : readOnly, Visible: isVisible);
        }
        // in your button click handler, just call PrintOut() function
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            // if doc == null, open the document
            if (doc == null)
            {
                // here i assume fileName has been assigned
                doc = word.Documents.Open(fileName, ReadOnly : readOnly, Visible: isVisible);
            }
            doc.PrintOut();
        }
    }
