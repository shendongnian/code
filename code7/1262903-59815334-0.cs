    private List<Task<bool>> taskTypeQueue = new List<Task<bool>>();
    private async void textBox_TextChanged(object sender, EventArgs e)
    {
        async Task<bool> isStillTyping()
        {
            Application.DoEvents();
    
            int taskCount = taskTypeQueue.Count;
            string oldStr = textBox.Text;
            await Task.Delay(1500);
    
            if ((oldStr != textBox.Text) || (taskCount != taskTypeQueue.Count - 1))
            {
                return true;
            }
    
            return false;
        }
    
        taskTypeQueue.Add(isStillTyping());
        if (await taskTypeQueue[taskTypeQueue.Count - 1])
            return;
    
        // typing appears to have stopped, continue
        taskTypeQueue.Clear();
    }
