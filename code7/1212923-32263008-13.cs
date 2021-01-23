    class AsyncWorkScheduler
    {
        public AsyncWorkScheduler(int numberOfSlots)
        {
            m_slots = new Task[numberOfSlots];
            m_availableSlots = new BufferBlock<int>();
            m_errors = new List<Exception>();
            m_tcs = new TaskCompletionSource<bool>();
            m_completionPending = 0;
            // Initial state: all slots are available
            for(int i = 0; i < m_slots.Length; ++i)
            {
                m_slots[i] = Task.FromResult(false);
                m_availableSlots.Post(i);
            }
        }
        public async Task ScheduleAsync(Func<int, Task> action)
        {
            if (Volatile.Read(ref m_completionPending) != 0)
            {
                throw new InvalidOperationException("Unable to schedule new items.");
            }
            
            // Acquire a slot 
            int slotNumber = await m_availableSlots.ReceiveAsync().ConfigureAwait(false);
            // Schedule a new task for a given slot
            var task = action(slotNumber);
            // Store a continuation on the task to handle completion events
            m_slots[slotNumber] = task.ContinueWith(t => HandleCompletedTask(t, slotNumber), TaskContinuationOptions.ExecuteSynchronously);
        }
        public async void Complete()
        {
            if (Interlocked.CompareExchange(ref m_completionPending, 1, 0) != 0)
            {
                return;
            }
            // Signal the queue's completion
            m_availableSlots.Complete();
            await Task.WhenAll(m_slots).ConfigureAwait(false);
         
            // Set completion
            if (m_errors.Count != 0)
            {
                m_tcs.TrySetException(m_errors);
            }
            else
            {
                m_tcs.TrySetResult(true);
            }
        }
        public Task Completion
        {
            get
            {
                return m_tcs.Task;
            }
        }
        void SetFailed(Exception error)
        {
            lock(m_errors)
            {
                m_errors.Add(error);
            }
        }
        void HandleCompletedTask(Task task, int slotNumber)
        {
           if (task.IsFaulted || task.IsCanceled)
           {
               SetFailed(task.Exception);
               return;
           }
           if (Volatile.Read(ref m_completionPending) == 1)
           {
               return;
           }
           
            // Release a slot
            m_availableSlots.Post(slotNumber);
        }
        int m_completionPending;
        List<Exception> m_errors;
        BufferBlock<int> m_availableSlots;
        TaskCompletionSource<bool> m_tcs;
        Task[] m_slots;
    }
