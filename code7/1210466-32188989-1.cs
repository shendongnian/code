    private delegate void OpenRtfDelegate();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            //Create word application
            var word = new Microsoft.Office.Interop.Word.Application();
                
            //Attach an eventn handler to word_Quit to open rft file after word quit.
            //If you try to load rtf before word quit, you will receive an exception that says file is in use.
            ((Microsoft.Office.Interop.Word.ApplicationEvents4_Event)word).Quit += word_Quit; 
                
            //Open word document
            var document = word.Documents.Open(@"Path_To_Word_File.docx", PasswordDocument: "Password_Of_Word_File");
                
            //Save as rft
            document.SaveAs2(@"Path_To_RFT_File.rtf", FileFormat: Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF);
            //Quit word
            ((Microsoft.Office.Interop.Word._Application)word).Quit(SaveChanges: Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    private void word_Quit()
    {
        //You sould load rtf this way, because word_Quit is running in a differet thread
        this.richTextBox1.BeginInvoke(new OpenRtfDelegate(OpenRtf));
    }
    
    private void OpenRtf()
    {
        this.richTextBox1.LoadFile(@"Path_To_RFT_File.rtf");
    }
