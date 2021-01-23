     enum MessageItems { 
            Processing, 
            Completed, 
            Error 
        }
        
        interface IMessages
        {
            MessageItems MessageVerification { set; }
            MessageItems MessageCreteUpload { set; }
            MessageItems MessageUploading { set; }
        }
