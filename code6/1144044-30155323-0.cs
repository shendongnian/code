    private void lang_portuguese_Click(object sender, EventArgs e)
    {
    new System.IO.StreamWriter(new System.IO.FileStream("File.ext", System.IO.FileMode.Create)).Write("Portuguese");
    }
    private void check_language()
    {
    String lang = new System.IO.StreamReader("YouFile.ext").ReadLine();
        if (lang == "English")
        {
            languages(); //Get the languages
            //Ignore
            lang_portuguese.Checked = false;
        }
        else if (lang == "Portuguese")
        {
            languages(); //Get the languages
            //Ignore
            lang_english.Checked = false;
        }
    }
