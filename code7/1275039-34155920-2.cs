    public partial class ProfileCreator : MetroWindow
    {
        public ProfileCreator(Network tempNetwork, UserProfile tempProfile)
        {
            InitializeComponent();
            // ...
        }
    
        async void btnSave_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO: Set cancelling when someting is missing
            await Save();
        }
    
        async Task Save()
        {
            getUserProfileValuesFromWindow();
    
            Globals.TheSerializer.Serialize(tempProfile, Globals.PathToTemporaryFiles + "MyProfile.xml");
    
            tempNetwork.NetworkParticipants.Add(tempProfile.ParticipantID);
    
            Globals.TheSerializer.Serialize(tempNetwork, Globals.PathToTemporaryFiles + "MyNetwork.xml");
    
            await Globals.Logger.outputMetroUserMessage(this, "Erfolg", "Ihr Testsystem wurde erfolgreich angelegt.\nDrücken Sie erneut auf \"Testen\" und loggen Sie sich ein.");
            await Globals.Logger.outputMetroUserMessage(this, UserErrorMessageController.GetTitleByID(104), UserErrorMessageController.GetMessageByID(104));
        }
    }
