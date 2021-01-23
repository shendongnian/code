    for (int i = 1; i < 35; i++) {
        string theControlNum = i < 1 ? "0" + i : i.ToString();
        if(this.Controls.Find($"label{theControlNum}").Text != "") {}
        else
        {
            this.Controls.Find($"btn{theControlNum}").visible = false; 
        }
    }
