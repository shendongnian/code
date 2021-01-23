      private void combineButton2_Click(object sender, EventArgs e)
        {
            var docList = new List<string>();
         // if statements to determine if the file is added
            if (selectedFile1 != null)
            {
                docList.Add(selectedFile1);
            };
            if (selectedFile2 != null)
            {
                docList.Add(selectedFile2);
            };
            if (selectedFile3 != null)
            {
                docList.Add(selectedFile3);
            };
            if (selectedFile4 != null)
            {
                docList.Add(selectedFile4);
            };
            if (selectedFile5 != null)
            {
                docList.Add(selectedFile5);
            };
            string[] docListString = docList.ToArray();
            if (outputFolder2 != @"")
            {
                loadingForm.Show(); // To show the form
            string fileDate = DateTime.Now.ToString("dd-MM-yy");
            string fileTime = DateTime.Now.ToString("HH.mm.ss");
            string outcomeFolder2 = outputFolder2;
            string outputFile2 = "Combined Files " + fileDate + " @ " + fileTime + ".docx";
            string outputFileName2 = Path.Combine(outcomeFolder2, outputFile2);
            MsWord.Merge(docListString, outputFileName2, true);
            loadingForm.Hide(); // to hide the form
            // Message displaying how many files are combined. 
            MessageBox.Show("The " + docListString.Length.ToString() + " individual Documents selected have been merged", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
