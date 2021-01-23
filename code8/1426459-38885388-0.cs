    private void Page_Loaded(object sender, RoutedEventArgs e) {
        var wnd = Window.GetWindow(this);
        wnd.ContentRendered += Wnd_ContentRendered;            
    }
    private void Wnd_ContentRendered(object sender, EventArgs e) {
        GetDataAsync();            
    }
     private async void GetDataAsync() {
            authenticationText.Text = "Connecting...";
            await Task.Delay(5000);
            authenticationText.Text = "Getting Member Details...";
            List<MemberServiceModel> memberList = await GetMembersAsync();
            // more code for handling response
    }
   
    private List<MemberServiceModel> GetMembers() {
                //get all members synchronous
                var request = new RestRequest("Members/Admin", Method.GET);
                var response = _client.Execute<List<MemberServiceModel>>(request);
                if (response.ResponseStatus != ResponseStatus.Completed) {
                    //TODO
                    _restErrorStatus = response.ResponseStatus.ToString();
                    _restErrorMessage = response.StatusDescription;
                    _logger.Error("Error in GetMembers");
                    _logger.Error("Status:" + _restErrorStatus);
                    _logger.Error("Description:" + _restErrorMessage);
                }
                return response.Data; ;
            }
    
            private Task<List<MemberServiceModel>> GetMembersAsync() {
                //get all members asynchronous
                return Task.Run(new Func<List<MemberServiceModel>>(GetMembers));
            }
