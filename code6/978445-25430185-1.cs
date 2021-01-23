        [Required(ErrorMessage="Password Required")]
        public string Password {
            get { return password; }
            set { password = value; RaisePropertyChanged("Password"); }
        }
        [EqualsValidationAttribute("Password", ErrorMessage = "Confirm password must be same as password")]
        public string ConfirmPassword {
            get { return confirmedpassword; }
            set { confirmedpassword = value; RaisePropertyChanged("ConfirmPassword"); }
        }
    }
    
