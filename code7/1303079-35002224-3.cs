    if (IsPostBack)
    {
        // validate the Captcha to check we're not dealing with a bot
        bool isHuman = SampleCaptcha.Validate(CaptchaCodeTextBox.Text);
        
        CaptchaCodeTextBox.Text = null; // clear previous user input
    
        if (!isHuman)
        {
          // TODO: Captcha validation failed, show error message  
        }
        else
        {
          // TODO: Captcha validation passed, proceed with protected action  
        }
    }
