        //Initialize .EML file    
        using (MailMessage eml = new MailMessage("test@from.to", "test@to.to", "template subject", "Template body"))
       {
           string oftEmlFileName = "EmlAsMSG_out.msg";
        
           MsgSaveOptions options = SaveOptions.DefaultMsg;
        
           //Save created .MSG file  
           options.SaveAsTemplate = true;
           eml.Save(oftEmlFileName, options);
        }
