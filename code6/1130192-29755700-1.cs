    ... ProjectContactsViewModel { 
      public string PhoneNo {get;set;} 
      public Command DialPhoneCommand {get;set;}
      ...
      public ProjectContactsViewModel(){
        DialPhoneCommand = new Command((phoneNo)=> 
          Device.OpenUri(new Uri("tel:" + phoneNo ));
        );
      }
    }
