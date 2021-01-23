    [Test]
    public void Can_count_tasks()
    {
        // Given
        var originalScheduler = TaskScheduler.Default;
        var defaultSchedulerField = typeof(TaskScheduler).GetField("s_defaultTaskScheduler", BindingFlags.Static | BindingFlags.NonPublic);
        var testScheduler = new TestTaskScheduler(originalScheduler);
        defaultSchedulerField.SetValue(null, testScheduler);
    
        // When
        Task.Run(() => {});
        Task.Run(() => {});
        Task.Run(() => {});
    
        // Then
        testScheduler.TaskCount.Should().Be(3);
        // Clean up
        defaultSchedulerField.SetValue(null, originalScheduler);
    }
