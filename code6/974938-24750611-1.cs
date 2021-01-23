    ImageButton icon = null;
    icon = new ImageButton{
    ...
      Command= new Command((tag)=>{
         icon.Source = ImageSource.FromFile("...");// see other .FromXYZ methods too
      },
      CommandParameter="<your tag here>",
    }
