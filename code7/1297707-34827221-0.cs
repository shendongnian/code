    private Process pNotepad;	//Process field
    void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if (e.Result.Text == "alice present")
        {
            SoundPlayer sndPlayer = new SoundPlayer(Ai.Properties.Resources.My_name_is_A_L_I_C_E);
            sndPlayer.Play();
        }
        if (e.Result.Text == "open notepad")
        {
			//starting Process "notepad"
			pNotepad = new Process();
			pNotepad.StartInfo.FileName = "notepad.exe";
        }
        if (e.Result.Text == "close notepad")
        {
            BtnN.PerformClick();
        }
    }
	
    private void BtnN_Click(object sender, EventArgs e)
    {
        //kill process if it is running
        if(pNotepad != null && pNotepad.HasExited == false)
    	    pNotepad.Kill();
    }
