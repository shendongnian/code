    public PasswordInputViewModel()
            {
                entry_Finished = new Command(validateAndContinue);//unfocused
                entry_Focused = new Command(entryFocused); //focused
            }
