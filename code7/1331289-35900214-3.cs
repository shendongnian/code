      IProgress<UploadStep> progress = new Progress<UploadStep>(step =>
      {
          // sample consumption of progress changed event.
          if (step.Complete)
          {
              // Do what ever you want at the end.
          }
          else
          {
              statusTxtBox.Text = step.Message;
          }
      }); 
