	CameraCaptureTask cameraCaptureTask = new CameraCaptureTask();
	cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);
	cameraCaptureTask.Show();
	void cameraCaptureTask_Completed(object sender, PhotoResult e)
	{
		try
		{
			if (e.TaskResult == TaskResult.OK)
			{
				// your code after get image capture
			}
		}
		catch (Exception ex)
		{
		}
	}
