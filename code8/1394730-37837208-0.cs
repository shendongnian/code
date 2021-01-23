        var feedback = new FeedBack();
        feedback.Name = name;
        feedback.Email = email;
        feedback.CreatDate = DateTime.Now;
        feedback.Phone = mobile;
        feedback.Content = content;
        feedback.Address = address;
        var id = new LHeDAO().InsertFeedBack(feedback);**
