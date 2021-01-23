    private void combineButton2_Click(object sender, EventArgs e)
        {
            var docList = new List<string>();
            docList.Add(selectedFile1);
            docList.Add(selectedFile2);
            docList.Add(selectedFile3);
            docList.Add(selectedFile4);
            docList.Add(selectedFile5);
            string[] docListString = new string[docList.Count];
            if (outputFolder2 != @"")
            {
                loadingForm.Show(); // To show the form
            string fileDate = DateTime.Now.ToString("dd-MM-yy");
            string fileTime = DateTime.Now.ToString("HH.mm.ss");
            string outcomeFolder2 = outputFolder2;
            string outputFile2 = "Combined Files " + fileDate + " @ " + fileTime + ".docx";
            string outputFileName2 = Path.Combine(outcomeFolder2, outputFile2);
            MsWord.Merge(docListString, outputFileName2, true);
