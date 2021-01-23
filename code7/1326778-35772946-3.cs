    private void Search_Video_Youtube(string page)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
        {
            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApplicationName = this.GetType().ToString(),
                ApiKey = "*MyApiKeyGoesHere*",
            });
            var listRequest = youtube.Search.List("snippet");
            listRequest.Q = Youtube_SearchVideo_Box.Text;
            listRequest.MaxResults = 50;
            listRequest.Type = "video";
            listRequest.PageToken = nextPageToken;
            video_results_vids = video_results_vids + 50;
            var resp = listRequest.Execute().OfType<SearchResult>();
            List<string> videos = new List<string>();
            Parallel.Foreach(resp.Items, (result) =>
            {
              
                switch (result.Id.Kind)
                {
                    case "youtube#video":
                        string template2 = "http://i3.ytimg.com/vi/{0}{1}";
                        string data2 = result.Id.VideoId.ToString();
                        string quality2 = "/default.jpg";
                        string messageB = string.Format(template2, data2, quality2);
                        Bitmap image;
                        var request = WebRequest.Create(messageB);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            image = Bitmap.FromStream(stream);
                        }
                        listnumber += 1;
 
                        this.Invoke(() =>
                        {
                            PictureBox picturebox = new PictureBox();
                            picturebox.Height = 100;
                            picturebox.Width = 100;
                            picturebox.Image = image;
                            picturebox.BorderStyle = BorderStyle.None;
                            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;        
                            flowLayoutPanel1.Controls.Add(picturebox);
                            Button button = new Button();
                            button.Text = listnumber.ToString() + " " + result.Snippet.Title.ToString();
                            button.Tag = result.Id.VideoId;
                            button.TextImageRelation = TextImageRelation.ImageBeforeText;
                            button.FlatStyle = FlatStyle.Flat;
                            button.ForeColor = Color.LightSteelBlue;
                            button.BackColor = Color.SteelBlue;
                            button.Width = (flowLayoutPanel1.Width - 150);
                            button.TextAlign = ContentAlignment.MiddleLeft;                        
                            button.Height = 100;
                            button.Font = new Font(button.Font.FontFamily, 10);
                            button.Click += (s, e) => {
                                Youtube_video_Player_hider.Visible = false;
                                var a = result.Id.VideoId;
                                string template = "https://www.youtube.com/v/{0}{1}";
                                string data = a.ToString();
                                string quality = Video_Quality;
                                string messagea = string.Format(template, data, quality);    
                                axShockwaveFlash1.Movie = messagea;
                                axShockwaveFlash1.Play();
                            };
                            flowLayoutPanel1.Controls.Add(button);
                        });
                        break;
                }
            nextPageToken = resp.NextPageToken;
            this.Invoke(() =>
            {
                toolStripStatusLabel1.Text = "Status : Idle";
                toolStripStatusLabel2.Text = "Results : " + video_results_vids;
            });
        }, null);
    }
