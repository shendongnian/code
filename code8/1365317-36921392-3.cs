	// Part of your composition root
	private sealed class HangfireBackgroundMailer : IMailer
	{
		public void SendFeedbackToSender(int feedbackId) {
			BackgroundJob.Enqueue<Mailer>(mailer => mailer.SendFeedbackToSender(notification.FeedbackId));
		}
		public void SendFeedbackToManagement(int feedbackId) {
			BackgroundJob.Enqueue<Mailer>(mailer => mailer.SendFeedbackToManagement(notification.FeedbackId));
		}
	}
