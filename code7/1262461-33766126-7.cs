    Intro.NextDelegate = this.GoToStep1;
    Step1.NextDelegate = this.GoToStep2;
    Step2.NextDelegate = this.GoToStep3;
    
    Step1.IsValidChanged += delegate { IsStep2Enabled = Step1.IsValid; }
    Step2.IsValidChanged += delegate { IsStep3Enabled = Step2.IsValid; }
