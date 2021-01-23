                this.ViewModel.GetDateTime();
                
                while (true)
                {
                    this.ViewModel.CurrentDateTime = DateTime.Now;
                    if (this.ViewModel.CurrentDateTime != DateTime.MinValue)
                        break;
                }
                curDateTime = this.ViewModel.CurrentDateTime;
  
