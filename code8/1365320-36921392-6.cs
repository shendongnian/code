	// Part of your composition root
	private sealed class HangfireBackgroundMailer : IMailer
	{
		public void SendFeedbackToSender(int feedbackId) {
			BackgroundJob.Enqueue<Mailer>(m => m.SendFeedbackToSender(feedbackId));
		}
		public void SendFeedbackToManagement(int feedbackId) {
			BackgroundJob.Enqueue<Mailer>(m => m.SendFeedbackToManagement(feedbackId));
		}
	}
