        public int LatestResult {get; set;}
        public void ClickEvent(object sender, EventArgs args)
        {
            new NotificationManager().Publish(new ResultChangedMessage(this.LatestResult2));
        }
    }
