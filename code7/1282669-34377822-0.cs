    foreach( string s in specials ) {
        if( TranslateBox.Text.Contains( s ) || TranslateBox.Text == "\"" ) {
            TranslateOutput.Text = "";
            MessageBox.Show( "No Special Characters!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            return;
        }
    }
    String[] parts = TranslateBox.Text.Split();
    foreach( String part in parts ) {
        foreach( String v in vowels ) {
            if( part.Substring( 0, 1 ) == v ) {
                TranslateOutput.Text = TranslateOutput.Text + " " + part + "ay";
                break;
            }
            else {
                if( part.Substring( 0, 2 ) == "sh" || part.Substring( 0, 2 ) == "ch" || part.Substring( 0, 2 ) == "th" || part.Substring( 0, 2 ) == "tr" ) {
                    string SwitchP = part.Substring( 2 ) + part.Substring( 0, 2 );
                    TranslateOutput.Text = TranslateOutput.Text + " " + SwitchP + "ay";
                    break;
                }
                else {
                    string Switch = part.Substring( 1 ) + part.Substring( 0, 1 );
                    TranslateOutput.Text = TranslateOutput.Text + " " + Switch + "ay";
                    break;
                }
            }
        }
    }
