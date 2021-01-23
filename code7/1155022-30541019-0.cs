            // Init
            List<Message> msgs = CurrentUser.DisplayedMessages;
            List<HooliganDB.Image> imgs = HooliganDB.Image.GetAll();
            if (MessageList.Items.Count < CurrentUser.DisplayedMessages.Count)
            {
                // New messages found, rebind data
                var resultTable = from m in msgs
                                  join i in imgs
                                  on m.ImageID equals i.ImageID
                                  select new
                                  {
                                      MessageID = m.MessageID,
                                      TimeStamp = m.TimeStamp,
                                      Text = m.Text,
                                      RoomID = m.RoomID,
                                      ImageID = m.ImageID,
                                      aspUserID = m.aspUserID,
                                      Path = i.Path
                                  };
                MessageList.DataSource = resultTable;
                MessageList.DataBind();
