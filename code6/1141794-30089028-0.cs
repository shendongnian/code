    private void btnSave_Click(object sender, EventArgs e)
    {
        LiteralControl message = new LiteralControl();
        try
        {
            Controls.Add(message);
            ConditionallyCreateList();
            SaveInputToList();
            List<ListColumns> listOfListItems = ReadFromList();
            GeneratePDF(listOfListItems); // using iTextSharp
            message.Text = "Saving the data and converting it to a PDF has been successful";
        }
        catch (Exception ex)
        {
            message.Text = String.Format("Exception occurred: {0}", ex.Message);
        }
    }
