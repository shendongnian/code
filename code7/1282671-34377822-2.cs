    private void TranslateButton_Click( object sender, EventArgs e )
    {
        char[] specials = "`1234567890-=[]\";',./~!@#$%^&*()_+{}|:\\<>?".ToArray();
        char[] vowels = "aeiou".ToArray();
        TranslateOutput.Text = String.Empty;
        if( TranslateBox.Text.IndexOfAny( specials ) > -1 ) {
            MessageBox.Show( "No Special Characters!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            return;
        }
        String[] parts = TranslateBox.Text.Split();
        foreach( String part in parts ) {
            int firstVowel = part.IndexOfAny( vowels );
            if( firstVowel > 0 ) {
                TranslateOutput.Text += part.Substring( firstVowel ) + part.Substring( 0, firstVowel ) + "ay ";
            }
            else {
                TranslateOutput.Text += part + "ay ";
            }
        }
        TranslateOutput.Text = TranslateOutput.Text.TrimEnd();
    }
